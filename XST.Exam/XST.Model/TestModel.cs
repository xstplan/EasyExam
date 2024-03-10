using SqlSugar;

namespace XST.Model
{

    [SugarTable("test_model", "测试表")]
    public class TestModel
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
