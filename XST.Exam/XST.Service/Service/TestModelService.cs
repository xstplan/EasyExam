using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XST.Model;
using XST.Service.Repository;
using XST.Service.Service.IService;

namespace XST.Service.Service
{
    public class TestModelService : BaseService<TestModel>, ITestModelService
    {
        public ToResponse<int> CreateTest(TestModel Test)
        {
            var result = Add(Test);
            if (result > 0)
            {
                return new ToResponse<int>() { Data = result, Success = true, Message = "创建成功" };
            }
            else
            {
                return new ToResponse<int>() { Data = result, Success = false, Message = "创建失败" };
            }
        }

        public ToResponse<int> DeleteTest(int examId)
        {
            var result = Delete(examId);
            if (result > 0)
            {
                return new ToResponse<int>() { Data = result, Success = true, Message = "删除成功" };
            }
            else
            {
                return new ToResponse<int>() { Data = result, Success = false, Message = "删除失败" };
            }
        }

        public ToResponse<List<TestModel>> GetAllTests()
        {
            var exams = GetAll();
            if (exams != null && exams.Count > 0)
            {
                return new ToResponse<List<TestModel>>() { Data = exams, Success = true, Message = "成功" };
            }
            else
            {
                return new ToResponse<List<TestModel>>() { Data = null, Success = false, Message = "没有数据" };
            }
        }

        public ToResponse<PagedInfo<TestModel>> GetPagedTests(PagerInfo pagerInfo)
        {
            var pagedExams = GetPaged(pagerInfo, e => e.Id);
            if (pagedExams != null)
            {
                return new ToResponse<PagedInfo<TestModel>>() { Data = pagedExams, Success = true, Message = "成功" };
            }
            else
            {
                return new ToResponse<PagedInfo<TestModel>>() { Data = null, Success = false, Message = "没有分页数据" };
            }
        }

        public ToResponse<PagedInfo<TestModel>> GetPagedTests(Expression<Func<TestModel, bool>> where, PagerInfo pagerInfo)
        {
            var pagedCourses = GetPages(where, pagerInfo, a => a.Id);
            if (pagedCourses != null)
            {
                return new ToResponse<PagedInfo<TestModel>>() { Data = pagedCourses, Success = true, Message = "成功" };
            }
            else
            {
                return new ToResponse<PagedInfo<TestModel>>() { Data = null, Success = false, Message = "没有分页数据" };
            }
        }

        public ToResponse<TestModel> GetTestById(int examId)
        {
            var exam = GetId(examId);
            if (exam != null)
            {
                return new ToResponse<TestModel>() { Data = exam, Success = true, Message = "成功" };
            }
            else
            {
                return new ToResponse<TestModel>() { Data = null, Success = false, Message = "不存在" };
            }
        }

      


        public ToResponse<int> UpdateTest(TestModel Test)
        {
            var result = Update(Test);
            if (result > 0)
            {
                return new ToResponse<int>() { Data = result, Success = true, Message = "更新成功" };
            }
            else
            {
                return new ToResponse<int>() { Data = result, Success = false, Message = "更新失败" };
            }
        }

        public ToResponse<int> UpdateTest(Expression<Func<TestModel, object>> whereExpression, TestModel Test)
        {
            var result = Update(Test, whereExpression);
            if (result > 0)
            {
                return new ToResponse<int>() { Data = result, Success = true, Message = "更新成功" };
            }
            else
            {
                return new ToResponse<int>() { Data = result, Success = false, Message = "更新失败" };
            }
        }

        public ToResponse<List<TestModel>> Where(Expression<Func<TestModel, bool>> whereExpression)
        {
            var list = GetList(whereExpression);
            if (list != null)
            {
                return new ToResponse<List<TestModel>>() { Data = list, Success = true, Message = "成功" };
            }
            else
            {
                return new ToResponse<List<TestModel>>() { Data = null, Success = false, Message = "没有数据" };
            }
        }
    }
}
