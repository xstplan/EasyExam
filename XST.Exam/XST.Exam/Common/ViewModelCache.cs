using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.Common
{
    public class ViewModelCache<T> 
    {
        private readonly Dictionary<string, T> cache;

        public ViewModelCache()
        {
            cache = new Dictionary<string, T>();
        }

        public T Get(string key)
        {
            if (cache.ContainsKey(key))
            {
                return cache[key];
            }
            else
            {
                // 如果键不存在，可以根据需要返回默认值或抛出异常等处理
                throw new ArgumentException($"Key '{key}' 在缓存中找不到.");
            }
        }

        public void Set(string key, T value)
        {
            if (cache.ContainsKey(key))
            {
                // 如果键已经存在，可以根据需要进行更新或抛出异常等处理
                cache[key] = value;
            }
            else
            {
                cache.Add(key, value);
            }
        }
    }
}
