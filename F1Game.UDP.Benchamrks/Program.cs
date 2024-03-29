﻿using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

using F1Game.UDP.Benchmarks;

var config = DefaultConfig.Instance
	.AddJob(Job.Default.WithId("NET7").WithRuntime(CoreRuntime.Core70))
	.AddJob(Job.Default.WithId("NET8").WithRuntime(CoreRuntime.Core80));

BenchmarkRunner.Run<ToPacketBenchmark>(config);
