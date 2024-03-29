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
    public class BaseTrainingRecordsService : BaseService<BaseTrainingRecords>, IBaseTrainingRecordsService
    {
        public ToResponse<int> CreateBaseTrainingRecord(BaseTrainingRecords trainingRecord)
        {
            var result = Add(trainingRecord);
            return GetResponse(result, "创建");
        }

        public ToResponse<int> DeleteBaseTrainingRecord(int trainingRecordId)
        {
            var result = Delete(trainingRecordId);
            return GetResponse(result, "删除");
        }

        public ToResponse<List<BaseTrainingRecords>> GetAllBaseTrainingRecords()
        {
            var trainingRecords = GetAll();
            return GetListResponse(trainingRecords);
        }

        public ToResponse<PagedInfo<BaseTrainingRecords>> GetPagedBaseTrainingRecords(PagerInfo pagerInfo)
        {
            var pagedTrainingRecords = GetPaged(pagerInfo, e => e.Id);
            return GetPagedResponse(pagedTrainingRecords);
        }

        public ToResponse<PagedInfo<BaseTrainingRecords>> GetPagedBaseTrainingRecords(Expression<Func<BaseTrainingRecords, bool>> where, PagerInfo pagerInfo)
        {
            var pagedTrainingRecords = GetPages(where, pagerInfo, e => e.Id);
            return GetPagedResponse(pagedTrainingRecords);
        }

        public ToResponse<BaseTrainingRecords> GetBaseTrainingRecordById(int trainingRecordId)
        {
            var trainingRecord = GetId(trainingRecordId);
            return GetSingleResponse(trainingRecord);
        }

        public ToResponse<int> UpdateBaseTrainingRecord(BaseTrainingRecords trainingRecord)
        {
            var result = Update(trainingRecord);
            return GetResponse(result, "更新");
        }

        public ToResponse<int> UpdateBaseTrainingRecord(Expression<Func<BaseTrainingRecords, object>> whereExpression, BaseTrainingRecords trainingRecord)
        {
            var result = Update(trainingRecord, whereExpression);
            return GetResponse(result, "更新");
        }

        public ToResponse<List<BaseTrainingRecords>> Where(Expression<Func<BaseTrainingRecords, bool>> whereExpression)
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

        private ToResponse<List<BaseTrainingRecords>> GetListResponse(List<BaseTrainingRecords> list)
        {
            return list != null && list.Count > 0
                ? new ToResponse<List<BaseTrainingRecords>>() { Data = list, Success = true, Message = "成功" }
                : new ToResponse<List<BaseTrainingRecords>>() { Data = null, Success = false, Message = "没有数据" };
        }

        private ToResponse<PagedInfo<BaseTrainingRecords>> GetPagedResponse(PagedInfo<BaseTrainingRecords> pagedList)
        {
            return pagedList != null
                ? new ToResponse<PagedInfo<BaseTrainingRecords>>() { Data = pagedList, Success = true, Message = "成功" }
                : new ToResponse<PagedInfo<BaseTrainingRecords>>() { Data = null, Success = false, Message = "没有分页数据" };
        }

        private ToResponse<BaseTrainingRecords> GetSingleResponse(BaseTrainingRecords item)
        {
            return item != null
                ? new ToResponse<BaseTrainingRecords>() { Data = item, Success = true, Message = "成功" }
                : new ToResponse<BaseTrainingRecords>() { Data = null, Success = false, Message = "不存在" };
        }
        
    }
}
