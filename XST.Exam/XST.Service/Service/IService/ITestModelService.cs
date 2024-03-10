using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XST.Model;
using XST.Service.Repository;

namespace XST.Service.Service.IService
{
    public interface ITestModelService
    {
        ToResponse<TestModel> GetTestById(int examId);

        ToResponse<List<TestModel>> GetAllTests();

        ToResponse<int> CreateTest(TestModel Test);

        ToResponse<int> UpdateTest(TestModel Test);

        ToResponse<int> DeleteTest(int examId);

        ToResponse<PagedInfo<TestModel>> GetPagedTests(PagerInfo pagerInfo);

        ToResponse<PagedInfo<TestModel>> GetPagedTests(Expression<Func<TestModel, bool>> where, PagerInfo pagerInfo);

        ToResponse<List<TestModel>> Where(Expression<Func<TestModel, bool>> whereExpression);


        ToResponse<int> UpdateTest(Expression<Func<TestModel, object>> whereExpression, TestModel Test);

 

   
    }
}
