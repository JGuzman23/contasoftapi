using contasoft_api.Data;
using contasoft_api.DTOs.Outputs;
using contasoft_api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using contasoft_api.Models;
using Microsoft.EntityFrameworkCore;

namespace contasoft_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanController : ControllerBase
    {
        private readonly ContaSoftDbContext _contaSoftDbContext;

        public PlanController(ContaSoftDbContext contaSoftDbContext)
        {
            _contaSoftDbContext = contaSoftDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = new DefaultResponse();
           

            List<PlanOutPut> PlanOutputList = new List<PlanOutPut>();

            var PlanList = await _contaSoftDbContext.Plan
                .Where(x => x.IsActive).ToListAsync();

            foreach (var plan in PlanList)
            {

                PlanOutPut PlanOutput = new PlanOutPut()
                {
                    ID = plan.ID,
                    Name = plan.Name,
                    Period = plan.Period,
                    Price = plan.Price,
                };

                PlanOutputList.Add(PlanOutput);
            }

          
            response.Message = "Success";
            response.StatusCode = 1;
            response.Success = true;
            response.Data = PlanOutputList;

            return Ok(response);

        }

    }
}
