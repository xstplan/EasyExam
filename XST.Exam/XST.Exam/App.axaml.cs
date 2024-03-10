using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SqlSugar.IOC;
using System;
using System.IO;
using System.Reflection;
using XST.Exam.ViewModels;
using XST.Exam.Views;
using XST.Service;
using XST.Service.Repository;
using XST.Service.Service;
using XST.Service.Service.IService;

namespace XST.Exam;

public partial class App : Application
{
    /// <summary>
    /// 在应用程序初始化时调用的方法
    /// </summary>
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this); // 加载Avalonia XAML文件
    }

    /// <summary>
    /// 创建主机并配置服务
    /// </summary>
    private static readonly IHost _host = Host.CreateDefaultBuilder()
        .ConfigureAppConfiguration(c =>
        {
            // 配置应用程序的基本路径
            c.SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location));
        })
        .ConfigureServices((context, services) =>
        {


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
            services.AddTransient<IBaseBaseExamWordService, BaseBaseExamWordService>();
            
        })
        .Build(); // 构建主机

    // 通过泛型方法获取服务
    public static T GetService<T>()
        where T : class
    {
        return _host.Services.GetService(typeof(T)) as T;
    }
   
    // 在框架初始化完成时调用的方法
    public override void OnFrameworkInitializationCompleted()
    {
        // 移除数据验证器的第一个元素
        BindingPlugins.DataValidators.RemoveAt(0);

        // 根据应用程序生命周期类型设置主窗口
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel()
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        // 启动主机
        _host.Start();

        // 调用基类的框架初始化完成方法
        base.OnFrameworkInitializationCompleted();
    }


}
