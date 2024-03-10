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
    public interface  IBaseBaseExamWordService
    {
        ToResponse<BaseExamWord> GetBaseExamWordById(int examWordId);

        ToResponse<List<BaseExamWord>> GetAllBaseExamWords();

        ToResponse<int> CreateBaseExamWord(BaseExamWord examWord);

        ToResponse<int> UpdateBaseExamWord(BaseExamWord examWord);

        ToResponse<int> DeleteBaseExamWord(int examWordId);

        ToResponse<PagedInfo<BaseExamWord>> GetPagedBaseExamWords(PagerInfo pagerInfo);

        ToResponse<PagedInfo<BaseExamWord>> GetPagedBaseExamWords(Expression<Func<BaseExamWord, bool>> where, PagerInfo pagerInfo);

        ToResponse<List<BaseExamWord>> Where(Expression<Func<BaseExamWord, bool>> whereExpression);

        ToResponse<int> UpdateBaseExamWord(Expression<Func<BaseExamWord, object>> whereExpression, BaseExamWord examWord);

    }
}
