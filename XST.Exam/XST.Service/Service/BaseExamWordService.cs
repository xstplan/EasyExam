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
    public class BaseBaseExamWordService : BaseService<BaseExamWord>, IBaseExamWordService
    {
        public ToResponse<int> CreateBaseExamWord(BaseExamWord examWord)
        {
            var result = Add(examWord);
            return GetResponse(result, "创建");
        }

        public ToResponse<int> DeleteBaseExamWord(int examWordId)
        {
            var result = Delete(examWordId);
            return GetResponse(result, "删除");
        }

        public ToResponse<List<BaseExamWord>> GetAllBaseExamWords()
        {
            var examWords = GetAll();
            return GetListResponse(examWords);
        }

        public ToResponse<PagedInfo<BaseExamWord>> GetPagedBaseExamWords(PagerInfo pagerInfo)
        {
            var pagedBaseExamWords = GetPaged(pagerInfo, e => e.Id);
            return GetPagedResponse(pagedBaseExamWords);
        }

        public ToResponse<PagedInfo<BaseExamWord>> GetPagedBaseExamWords(Expression<Func<BaseExamWord, bool>> where, PagerInfo pagerInfo)
        {
            var pagedBaseExamWords = GetPages(where, pagerInfo, e => e.Id);
            return GetPagedResponse(pagedBaseExamWords);
        }

        public ToResponse<BaseExamWord> GetBaseExamWordById(int examWordId)
        {
            var examWord = GetId(examWordId);
            return GetSingleResponse(examWord);
        }

        public ToResponse<int> UpdateBaseExamWord(BaseExamWord examWord)
        {
            var result = Update(examWord);
            return GetResponse(result, "更新");
        }

        public ToResponse<int> UpdateBaseExamWord(Expression<Func<BaseExamWord, object>> whereExpression, BaseExamWord examWord)
        {
            var result = Update(examWord, whereExpression);
            return GetResponse(result, "更新");
        }

        public ToResponse<List<BaseExamWord>> Where(Expression<Func<BaseExamWord, bool>> whereExpression)
        {
            var list = GetList(whereExpression);
            return GetListResponse(list);
        }

        private ToResponse<int> GetResponse(int result, string operation)
        {
            return result > 0
                ? new ToResponse<int>() { Data = result, Success = true, Message = $"{operation}成功" }
                : new ToResponse<int>() { Data = result, Success = false, Message = $"{operation}失败" };
        }

        private ToResponse<List<BaseExamWord>> GetListResponse(List<BaseExamWord> list)
        {
            return list != null && list.Count > 0
                ? new ToResponse<List<BaseExamWord>>() { Data = list, Success = true, Message = "成功" }
                : new ToResponse<List<BaseExamWord>>() { Data = null, Success = false, Message = "没有数据" };
        }

        private ToResponse<PagedInfo<BaseExamWord>> GetPagedResponse(PagedInfo<BaseExamWord> pagedList)
        {
            return pagedList != null
                ? new ToResponse<PagedInfo<BaseExamWord>>() { Data = pagedList, Success = true, Message = "成功" }
                : new ToResponse<PagedInfo<BaseExamWord>>() { Data = null, Success = false, Message = "没有分页数据" };
        }

        private ToResponse<BaseExamWord> GetSingleResponse(BaseExamWord item)
        {
            return item != null
                ? new ToResponse<BaseExamWord>() { Data = item, Success = true, Message = "成功" }
                : new ToResponse<BaseExamWord>() { Data = null, Success = false, Message = "不存在" };
        }
    }
}
