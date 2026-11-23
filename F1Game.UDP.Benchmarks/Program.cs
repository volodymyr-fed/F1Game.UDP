using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

var config = DefaultConfig.Instance
	.AddJob(Job.Default.WithId("NET9").WithRuntime(CoreRuntime.Core90))
	.AddJob(Job.Default.WithId("NET10").WithRuntime(CoreRuntime.Core10_0))
	.AddJob(Job.Default.WithId("NET11").WithRuntime(CoreRuntime.Core11_0));

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly)
	.Run(args, config);
