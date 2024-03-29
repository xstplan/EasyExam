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
    public interface IBaseTrainingRecordsService
    {
        ToResponse<BaseTrainingRecords> GetBaseTrainingRecordById(int trainingRecordId);

        ToResponse<List<BaseTrainingRecords>> GetAllBaseTrainingRecords();

        ToResponse<int> CreateBaseTrainingRecord(BaseTrainingRecords trainingRecord);

        ToResponse<int> UpdateBaseTrainingRecord(BaseTrainingRecords trainingRecord);

        ToResponse<int> DeleteBaseTrainingRecord(int trainingRecordId);

        ToResponse<PagedInfo<BaseTrainingRecords>> GetPagedBaseTrainingRecords(PagerInfo pagerInfo);

        ToResponse<PagedInfo<BaseTrainingRecords>> GetPagedBaseTrainingRecords(Expression<Func<BaseTrainingRecords, bool>> where, PagerInfo pagerInfo);

        ToResponse<List<BaseTrainingRecords>> Where(Expression<Func<BaseTrainingRecords, bool>> whereExpression);

        ToResponse<int> UpdateBaseTrainingRecord(Expression<Func<BaseTrainingRecords, object>> whereExpression, BaseTrainingRecords trainingRecord);
  

    }
}
