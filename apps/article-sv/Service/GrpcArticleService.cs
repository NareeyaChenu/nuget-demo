using Api.GrpcServerSc;
using Grpc.Core;

namespace article_sv.Service
{
    public class ArticleServerSercice  : Article.ArticleBase
    {
        public override Task<GetReply> Get (GetRequest request ,  ServerCallContext context)
        {
            Console.WriteLine("Ok");
            GetReply reply = new GetReply();

            reply.Message = "This article name " + request.Name;


            return Task.FromResult(reply);
        }
    }
}