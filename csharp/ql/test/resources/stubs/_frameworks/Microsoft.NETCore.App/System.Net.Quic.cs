// This file contains auto-generated code.
// Generated from `System.Net.Quic, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a`.
namespace System
{
    namespace Net
    {
        namespace Quic
        {
            [System.Flags]
            public enum QuicAbortDirection
            {
                Read = 1,
                Write = 2,
                Both = 3,
            }
            public sealed class QuicClientConnectionOptions : System.Net.Quic.QuicConnectionOptions
            {
                public System.Net.Security.SslClientAuthenticationOptions ClientAuthenticationOptions { get => throw null; set { } }
                public QuicClientConnectionOptions() => throw null;
                public System.Net.IPEndPoint LocalEndPoint { get => throw null; set { } }
                public System.Net.EndPoint RemoteEndPoint { get => throw null; set { } }
            }
            public sealed class QuicConnection : System.IAsyncDisposable
            {
                public System.Threading.Tasks.ValueTask<System.Net.Quic.QuicStream> AcceptInboundStreamAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) => throw null;
                public System.Threading.Tasks.ValueTask CloseAsync(long errorCode, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) => throw null;
                public static System.Threading.Tasks.ValueTask<System.Net.Quic.QuicConnection> ConnectAsync(System.Net.Quic.QuicClientConnectionOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) => throw null;
                public System.Threading.Tasks.ValueTask DisposeAsync() => throw null;
                public static bool IsSupported { get => throw null; }
                public System.Net.IPEndPoint LocalEndPoint { get => throw null; }
                public System.Net.Security.SslApplicationProtocol NegotiatedApplicationProtocol { get => throw null; }
                public System.Threading.Tasks.ValueTask<System.Net.Quic.QuicStream> OpenOutboundStreamAsync(System.Net.Quic.QuicStreamType type, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) => throw null;
                public System.Security.Cryptography.X509Certificates.X509Certificate RemoteCertificate { get => throw null; }
                public System.Net.IPEndPoint RemoteEndPoint { get => throw null; }
                public string TargetHostName { get => throw null; }
                public override string ToString() => throw null;
            }
            public abstract class QuicConnectionOptions
            {
                public long DefaultCloseErrorCode { get => throw null; set { } }
                public long DefaultStreamErrorCode { get => throw null; set { } }
                public System.TimeSpan HandshakeTimeout { get => throw null; set { } }
                public System.TimeSpan IdleTimeout { get => throw null; set { } }
                public System.Net.Quic.QuicReceiveWindowSizes InitialReceiveWindowSizes { get => throw null; set { } }
                public System.TimeSpan KeepAliveInterval { get => throw null; set { } }
                public int MaxInboundBidirectionalStreams { get => throw null; set { } }
                public int MaxInboundUnidirectionalStreams { get => throw null; set { } }
                public System.Action<System.Net.Quic.QuicConnection, System.Net.Quic.QuicStreamCapacityChangedArgs> StreamCapacityCallback { get => throw null; set { } }
            }
            public enum QuicError
            {
                Success = 0,
                InternalError = 1,
                ConnectionAborted = 2,
                StreamAborted = 3,
                ConnectionTimeout = 6,
                ConnectionRefused = 8,
                VersionNegotiationError = 9,
                ConnectionIdle = 10,
                OperationAborted = 12,
                AlpnInUse = 13,
                TransportError = 14,
                CallbackError = 15,
            }
            public sealed class QuicException : System.IO.IOException
            {
                public long? ApplicationErrorCode { get => throw null; }
                public QuicException(System.Net.Quic.QuicError error, long? applicationErrorCode, string message) => throw null;
                public System.Net.Quic.QuicError QuicError { get => throw null; }
                public long? TransportErrorCode { get => throw null; }
            }
            public sealed class QuicListener : System.IAsyncDisposable
            {
                public System.Threading.Tasks.ValueTask<System.Net.Quic.QuicConnection> AcceptConnectionAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) => throw null;
                public System.Threading.Tasks.ValueTask DisposeAsync() => throw null;
                public static bool IsSupported { get => throw null; }
                public static System.Threading.Tasks.ValueTask<System.Net.Quic.QuicListener> ListenAsync(System.Net.Quic.QuicListenerOptions options, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) => throw null;
                public System.Net.IPEndPoint LocalEndPoint { get => throw null; }
                public override string ToString() => throw null;
            }
            public sealed class QuicListenerOptions
            {
                public System.Collections.Generic.List<System.Net.Security.SslApplicationProtocol> ApplicationProtocols { get => throw null; set { } }
                public System.Func<System.Net.Quic.QuicConnection, System.Net.Security.SslClientHelloInfo, System.Threading.CancellationToken, System.Threading.Tasks.ValueTask<System.Net.Quic.QuicServerConnectionOptions>> ConnectionOptionsCallback { get => throw null; set { } }
                public QuicListenerOptions() => throw null;
                public int ListenBacklog { get => throw null; set { } }
                public System.Net.IPEndPoint ListenEndPoint { get => throw null; set { } }
            }
            public sealed class QuicReceiveWindowSizes
            {
                public int Connection { get => throw null; set { } }
                public QuicReceiveWindowSizes() => throw null;
                public int LocallyInitiatedBidirectionalStream { get => throw null; set { } }
                public int RemotelyInitiatedBidirectionalStream { get => throw null; set { } }
                public int UnidirectionalStream { get => throw null; set { } }
            }
            public sealed class QuicServerConnectionOptions : System.Net.Quic.QuicConnectionOptions
            {
                public QuicServerConnectionOptions() => throw null;
                public System.Net.Security.SslServerAuthenticationOptions ServerAuthenticationOptions { get => throw null; set { } }
            }
            public sealed class QuicStream : System.IO.Stream
            {
                public void Abort(System.Net.Quic.QuicAbortDirection abortDirection, long errorCode) => throw null;
                public override System.IAsyncResult BeginRead(byte[] buffer, int offset, int count, System.AsyncCallback callback, object state) => throw null;
                public override System.IAsyncResult BeginWrite(byte[] buffer, int offset, int count, System.AsyncCallback callback, object state) => throw null;
                public override bool CanRead { get => throw null; }
                public override bool CanSeek { get => throw null; }
                public override bool CanTimeout { get => throw null; }
                public override bool CanWrite { get => throw null; }
                public void CompleteWrites() => throw null;
                protected override void Dispose(bool disposing) => throw null;
                public override System.Threading.Tasks.ValueTask DisposeAsync() => throw null;
                public override int EndRead(System.IAsyncResult asyncResult) => throw null;
                public override void EndWrite(System.IAsyncResult asyncResult) => throw null;
                public override void Flush() => throw null;
                public override System.Threading.Tasks.Task FlushAsync(System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) => throw null;
                public long Id { get => throw null; }
                public override long Length { get => throw null; }
                public override long Position { get => throw null; set { } }
                public override int Read(byte[] buffer, int offset, int count) => throw null;
                public override int Read(System.Span<byte> buffer) => throw null;
                public override System.Threading.Tasks.Task<int> ReadAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) => throw null;
                public override System.Threading.Tasks.ValueTask<int> ReadAsync(System.Memory<byte> buffer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) => throw null;
                public override int ReadByte() => throw null;
                public System.Threading.Tasks.Task ReadsClosed { get => throw null; }
                public override int ReadTimeout { get => throw null; set { } }
                public override long Seek(long offset, System.IO.SeekOrigin origin) => throw null;
                public override void SetLength(long value) => throw null;
                public override string ToString() => throw null;
                public System.Net.Quic.QuicStreamType Type { get => throw null; }
                public override void Write(byte[] buffer, int offset, int count) => throw null;
                public override void Write(System.ReadOnlySpan<byte> buffer) => throw null;
                public override System.Threading.Tasks.Task WriteAsync(byte[] buffer, int offset, int count, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) => throw null;
                public System.Threading.Tasks.ValueTask WriteAsync(System.ReadOnlyMemory<byte> buffer, bool completeWrites, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) => throw null;
                public override System.Threading.Tasks.ValueTask WriteAsync(System.ReadOnlyMemory<byte> buffer, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken)) => throw null;
                public override void WriteByte(byte value) => throw null;
                public System.Threading.Tasks.Task WritesClosed { get => throw null; }
                public override int WriteTimeout { get => throw null; set { } }
            }
            public struct QuicStreamCapacityChangedArgs
            {
                public int BidirectionalIncrement { get => throw null; set { } }
                public int UnidirectionalIncrement { get => throw null; set { } }
            }
            public enum QuicStreamType
            {
                Unidirectional = 0,
                Bidirectional = 1,
            }
        }
    }
}
