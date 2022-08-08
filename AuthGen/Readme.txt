本项目为控制台代码生成器项目，直接运行此项目，即可生成代码。

注意:运行此项目之前，请先修改 Program.cs 文件中的两行配置

将下面两个路径配置为自己电脑上的MASA对应项目的文件路径。配置完后，运行控制台，即可在对应项目
的Gen文件夹下，看到生成的代码了。

Config.ContractsDir = @"D:\Devops\MASA.Auth\src\Contracts\Masa.Auth.Contracts.Admin\Gen";
Config.ServicesDir = @"D:\Devops\MASA.Auth\src\Services\Masa.Auth.Service.Admin\Gen";