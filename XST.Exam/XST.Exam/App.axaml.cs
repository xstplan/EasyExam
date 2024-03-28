using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls.Templates;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using SqlSugar.IOC;

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using XST.Exam.Common;
using XST.Exam.Helper;
using XST.Exam.Model;
using XST.Exam.ViewModels;
using XST.Exam.ViewModels.Controls;
using XST.Exam.ViewModels.Page;
using XST.Exam.Views;
using XST.Exam.Views.Controls;
using XST.Service;
using XST.Service.Repository;
using XST.Service.Service;
using XST.Service.Service.IService;

namespace XST.Exam;

public partial class App : Application
{
    public IServiceProvider Services { get; }

    public App() 
    {
        Services = ConfigureServices();
    }
    /// <summary>
    /// 在应用程序初始化时调用的方法
    /// </summary>
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this); // 加载Avalonia XAML文件
    }

    public new static App Current => (App)Application.Current;

    // 在框架初始化完成时调用的方法
    public override void OnFrameworkInitializationCompleted()
    {
        // 移除数据验证器的第一个元素
        BindingPlugins.DataValidators.RemoveAt(0);

        // 根据应用程序生命周期类型设置主窗口
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
       
            desktop.MainWindow = new MainView();

        }
        // 调用基类的框架初始化完成方法
        base.OnFrameworkInitializationCompleted();
    }
    
    private static ServiceProvider ConfigureServices()
    {

        var services = new ServiceCollection();

        // 向依赖注入容器中添加SqlSugar服务
        SugarIocServices.AddSqlSugar(new IocConfig()
        {
            ConnectionString = @"DataSource=" + Environment.CurrentDirectory + @"\DataBase\EE.db",
            DbType = IocDbType.Sqlite,
            IsAutoCloseConnection = true,
            ConfigId = 0
        });
        SugarIocServices.ConfigurationSugar(db =>
        {
            db.Aop.OnLogExecuting = (sql, p) =>
            {
                Console.WriteLine(sql);
            };
        });

        // 初始化数据库表
        InitTable.InitDb();

        services.AddTransient<ITestModelService, TestModelService>();
        services.AddTransient<IBaseExamWordService, BaseBaseExamWordService>();
        services.AddTransient<IBaseTrainingRecordsService, BaseTrainingRecordsService>();



        //Viewmodel
        services.AddTransient<MainViewModel>();
        services.AddTransient<WordTrainViewModel>();
        services.AddTransient<WordTrainViewModel>();
        services.AddTransient<WordAddViewModel>();
        services.AddTransient<WordStartViewModel>();
        services.AddTransient<WordRunViewModel>();
        services.AddTransient<WordEndViewModel>();
        services.AddTransient<WordSettingViewModel>();
        services.AddTransient<WordAddDialogViewModel>();

        
        return services.BuildServiceProvider();

    }
}
