
using Api.GrpcClientSv;
using Grpc.Net.Client;
using GrpcClientSv.Interface;

namespace GrpcClientSv.Services
{
  public class ArticleService : IArticleClientSv
  {
    private readonly ILogger<ArticleService> logger;

    public ArticleService(ILogger<ArticleService> logger)
    {
      this.logger = logger;
    }
    public GetReply Get(GetRequest msg)
    {
      var httpHandler = new HttpClientHandler();
      httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
      string endpoint = "https://localhost:7227";

      var channel = GrpcChannel.ForAddress(endpoint, new GrpcChannelOptions { HttpHandler = httpHandler });
      var client = new Article.ArticleClient(channel);

      try
      {
        var reply = client.Get(msg);
        return reply;

      }
      catch (Exception e)
      {

        logger.LogError(e.Message, e);
        return null!;
      }
    }
  }
}