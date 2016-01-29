using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Demo.Domain.Service.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values/5
        //public string Get(int id, [FromUri]string[] procedureCodes)
		public IHttpActionResult Get([FromUri]Inputs inputs)
		{
			if (ModelState.IsValid)
			{
				return Ok("value");
			}

			//return GetBuiltInBadRequest(ModelState);
			//return GetCustomShapedBadRequest(ModelState);

			return GetConcatenatedErrorMessageBadRequest(ModelState);
		}

	    private IHttpActionResult GetCustomShapedBadRequest(ModelStateDictionary state)
	    {
		    var errors = ModelState.Values.SelectMany(m => m.Errors);

		    var negotiator = Configuration.Services.GetContentNegotiator();
		    var result = negotiator.Negotiate(typeof (IEnumerable<ModelError>), Request, Configuration.Formatters);

			var response = new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
		    response.Content = new ObjectContent<IEnumerable<ModelError>>(errors, result.Formatter, result.MediaType.MediaType);

		    return ResponseMessage(response);
	    }

	    private IHttpActionResult GetConcatenatedErrorMessageBadRequest(ModelStateDictionary state)
	    {
		    var message = string.Join("|",
			    state.Values.SelectMany(m => m.Errors)
				    .Select(e => e.ErrorMessage)
				    .ToArray());
		    return BadRequest(message);
	    }

	    private IHttpActionResult GetBuiltInBadRequest(ModelStateDictionary state)
	    {
		    return BadRequest(state);
	    }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

	public class Inputs
	{
		[Required(ErrorMessage = "{0} is a required parameter")]
		public int Id { get; set; }

		[Required(ErrorMessage = "{0} is a required parameter")]
		public string[] ProcedureCodes { get; set; }
	}
}
