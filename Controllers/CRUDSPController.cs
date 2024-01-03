using CRUDWithSP.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Data;

namespace CRUDWithSP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CRUDSPController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public CRUDSPController(ApplicationDbContext _context)
        {
            context = _context;
        }

        [HttpPost("[action]")]
        public dynamic add(CRUDInfo entity)
        {
            object[] parameters = { entity.ID, entity.Name, entity.Mobile };
            string spQuery = "EXEC [dbo].[sp_Add_CRUD_Info] {0}, {1}, {2}";

            var menu = context.Database.ExecuteSqlRaw(spQuery, parameters);
            return 0;
        }
        [HttpPost("[action]")]
        public dynamic add2(CRUDInfo entity)
        {
            DataTable testDataTable = new DataTable();
            testDataTable.Columns.Add("Name", typeof(string));
            testDataTable.Columns.Add("Mobile", typeof(string));
            testDataTable.Rows.Add(entity.Name, entity.Mobile);
            //testDataTable.Rows.Add(2, entity.Mobile);
            var parameter = new SqlParameter("@CRUDInfo", SqlDbType.Structured);
            parameter.Value = testDataTable;
            parameter.TypeName = "dbo.tblCRUDInfo";

            var data = context.Database.ExecuteSqlInterpolated($"EXEC sp_Add_CRUD_Info @CRUDInfo = {parameter}");
            return Ok();





            string spQuery = "EXEC [dbo].[sp_Add_CRUD_Info] {0}";

            var menu = context.Database.ExecuteSqlRaw(spQuery, testDataTable);
            return 0;
        }
    }
}
