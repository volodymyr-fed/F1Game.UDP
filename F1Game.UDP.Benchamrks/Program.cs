using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

var config = DefaultConfig.Instance
	.AddJob(Job.Default.WithId("NET8").WithRuntime(CoreRuntime.Core80))
	.AddJob(Job.Default.WithId("NET9").WithRuntime(CoreRuntime.Core90));

BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly)
	.Run(args, config);
