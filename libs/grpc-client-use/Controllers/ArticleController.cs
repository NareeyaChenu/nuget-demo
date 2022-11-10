using Api.GrpcClientSv;
using GrpcClientSv.Interface;
using Microsoft.AspNetCore.Mvc;

namespace grpc_client_use.Controller
{
  [ApiController]
  [Route("api/article/articles")]
  public class ArticleController : ControllerBase
  {
    private readonly IArticleClientSv articleClientService;

    public ArticleController(IArticleClientSv articleClientService)
    {
      this.articleClientService = articleClientService;
    }

    [HttpGet]
    public ActionResult<GetReply> Get([FromQuery] GetRequest request)
    {
      
       
       return Ok(articleClientService.Get(request));
         
    }
    
  }
}