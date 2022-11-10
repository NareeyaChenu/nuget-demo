using Api.GrpcClientSv;

namespace GrpcClientSv.Interface
{
    public interface IArticleClientSv
    {
        public GetReply Get (GetRequest msg);
    }
}