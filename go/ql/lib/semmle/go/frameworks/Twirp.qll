/** Provides models of commonly used functions and types in the twirp packages. */

import go
private import semmle.go.security.RequestForgeryCustomizations

/** Provides models of commonly used functions and types in the twirp packages. */
module Twirp {
  /**
   * A *.pb.go file generated by Twirp.
   *
   * This file contains all the types representing protobuf messages and should have a companion *.twirp.go file.
   */
  class ProtobufGeneratedFile extends File {
    ProtobufGeneratedFile() {
      exists(string prefix, File f |
        prefix = this.getBaseName().regexpCapture("^(.*)\\.pb\\.go$", 1) and
        this.getParentContainer() = f.getParentContainer() and
        f.getBaseName() = prefix + ".twirp.go"
      )
    }
  }

  /**
   * A *.twirp.go file generated by Twirp.
   *
   * This file contains all the types representing protobuf services and should have a companion *.pb.go file.
   */
  class ServicesGeneratedFile extends File {
    ServicesGeneratedFile() {
      exists(string prefix, File f |
        prefix = this.getBaseName().regexpCapture("^(.*)\\.twirp\\.go$", 1) and
        this.getParentContainer() = f.getParentContainer() and
        f.getBaseName() = prefix + ".pb.go"
      )
    }
  }

  /** A type representing a protobuf message. */
  class ProtobufMessageType extends Type {
    ProtobufMessageType() {
      this.hasLocationInfo(any(ProtobufGeneratedFile f).getAbsolutePath(), _, _, _, _)
    }
  }

  /** An interface type representing a Twirp service. */
  class ServiceInterfaceType extends InterfaceType {
    DefinedType definedType;

    ServiceInterfaceType() {
      definedType.getUnderlyingType() = this and
      definedType.hasLocationInfo(any(ServicesGeneratedFile f).getAbsolutePath(), _, _, _, _)
    }

    /** Gets the name of the interface. */
    override string getName() { result = definedType.getName() }

    /** DEPRECATED: Use `getDefinedType` instead. */
    deprecated DefinedType getNamedType() { result = this.getDefinedType() }

    /** Gets the defined type on top of this interface type. */
    DefinedType getDefinedType() { result = definedType }
  }

  /** A Twirp client. */
  class ServiceClientType extends DefinedType {
    ServiceClientType() {
      exists(ServiceInterfaceType i, PointerType p |
        p.implements(i) and
        this = p.getBaseType() and
        this.getName().regexpMatch("(?i)" + i.getName() + "(protobuf|json)client") and
        this.hasLocationInfo(any(ServicesGeneratedFile f).getAbsolutePath(), _, _, _, _)
      )
    }
  }

  /** A Twirp server. */
  class ServiceServerType extends DefinedType {
    ServiceServerType() {
      exists(ServiceInterfaceType i |
        this.implements(i) and
        this.getName().regexpMatch("(?i)" + i.getName() + "server") and
        this.hasLocationInfo(any(ServicesGeneratedFile f).getAbsolutePath(), _, _, _, _)
      )
    }
  }

  /** A Twirp function to construct a Client. */
  class ClientConstructor extends Function {
    ClientConstructor() {
      this.getName().regexpMatch("(?i)new" + any(ServiceClientType c).getName()) and
      this.getParameterType(0) instanceof StringType and
      this.getParameterType(1).getName() = "HTTPClient" and
      this.hasLocationInfo(any(ServicesGeneratedFile f).getAbsolutePath(), _, _, _, _)
    }
  }

  /**
   * A Twirp function to construct a Server.
   *
   * Its first argument should be an implementation of the service interface.
   */
  class ServerConstructor extends Function {
    ServerConstructor() {
      this.getName().regexpMatch("(?i)new" + any(ServiceServerType c).getName()) and
      this.getParameterType(0) = any(ServiceInterfaceType i).getDefinedType() and
      this.hasLocationInfo(any(ServicesGeneratedFile f).getAbsolutePath(), _, _, _, _)
    }
  }

  /** An SSRF sink for the Client constructor. */
  class ClientRequestUrlAsSink extends RequestForgery::Sink {
    ClientRequestUrlAsSink() {
      exists(DataFlow::CallNode call |
        call.getArgument(0) = this and
        call.getTarget() instanceof ClientConstructor
      )
    }

    override DataFlow::Node getARequest() { result = this }

    override string getKind() { result = "URL" }
  }

  bindingset[m]
  pragma[inline_late]
  private predicate implementsServiceType(Method m) {
    m.implements(any(ServiceInterfaceType i).getDefinedType().getMethod(_))
  }

  /** A service handler. */
  class ServiceHandler extends Method {
    ServiceHandler() {
      exists(DataFlow::CallNode call |
        call.getTarget() instanceof ServerConstructor and
        this = call.getArgument(0).getType().getMethod(_) and
        implementsServiceType(this)
      )
    }
  }

  /** A request coming to the service handler. */
  class Request extends RemoteFlowSource::Range instanceof DataFlow::ParameterNode {
    Request() {
      exists(ServiceHandler handler |
        this.asParameter().isParameterOf(handler.getFuncDecl(), 1) and
        handler.getParameterType(0).hasQualifiedName("context", "Context") and
        this.getType().(PointerType).getBaseType() instanceof ProtobufMessageType
      )
    }
  }
}
