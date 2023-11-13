using AutoFixture;
using AutoFixture.Dsl;

using F1Game.UDP.Data;
using F1Game.UDP.Enums;
using F1Game.UDP.Events;
using F1Game.UDP.Packets;

namespace F1Game.UDP.Tests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
sealed class PacketReaderFixture
{
	readonly Fixture fixture = new();

	[Test]
	public void ReadCarDamageDataPacket()
	{
		var packet = BuildPacket<CarDamageDataPacket>()
			.With(x => x.CarDamageData, fixture.CreateMany<CarDamageData>(22).ToArray())
			.Create();

		var bytes = new byte[CarDamageDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadCarSetupDataPacket()
	{
		var packet = BuildPacket<CarSetupDataPacket>()
			.With(x => x.CarSetups, fixture.CreateMany<CarSetupData>(22).ToArray())
			.Create();

		var bytes = new byte[CarSetupDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadCarStatusDataPacket()
	{
		var packet = BuildPacket<CarStatusDataPacket>()
			.With(x => x.CarStatusData, fixture.CreateMany<CarStatusData>(22).ToArray())
			.Create();

		var bytes = new byte[CarStatusDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadCarTelemetryDataPacket()
	{
		var packet = BuildPacket<CarTelemetryDataPacket>()
			.With(x => x.CarTelemetryData, fixture.CreateMany<CarTelemetryData>(22).ToArray())
			.Create();

		var bytes = new byte[CarTelemetryDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	[TestCase(EventType.ButtonStatus)]
	[TestCase(EventType.ChequeredFlag)]
	[TestCase(EventType.DriveThroughServed)]
	[TestCase(EventType.DRSDisabled)]
	[TestCase(EventType.DRSEnabled)]
	[TestCase(EventType.FastestLap)]
	[TestCase(EventType.Flashback)]
	[TestCase(EventType.LightsOut)]
	[TestCase(EventType.Overtake)]
	[TestCase(EventType.PenaltyIssued)]
	[TestCase(EventType.RaceWinner)]
	[TestCase(EventType.RedFlag)]
	[TestCase(EventType.Retirement)]
	[TestCase(EventType.SessionStarted)]
	[TestCase(EventType.SessionEnded)]
	[TestCase(EventType.StartLights)]
	[TestCase(EventType.StopGoServed)]
	[TestCase(EventType.SpeedTrapTriggered)]
	[TestCase(EventType.TeamMateInPits)]
	public void ReadEventDataPacket(EventType eventType)
	{
		IEventDetails? eventDetails = eventType switch
		{
			EventType.FastestLap => fixture.Create<FastestLapEvent>(),
			EventType.Retirement => fixture.Create<RetirementEvent>(),
			EventType.TeamMateInPits => fixture.Create<TeamMateInPitsEvent>(),
			EventType.RaceWinner => fixture.Create<RaceWinnerEvent>(),
			EventType.PenaltyIssued => fixture.Create<PenaltyEvent>(),
			EventType.SpeedTrapTriggered => fixture.Create<SpeedTrapEvent>(),
			EventType.StartLights => fixture.Create<StartLightsEvent>(),
			EventType.DriveThroughServed => fixture.Create<DriveThroughPenaltyServedEvent>(),
			EventType.StopGoServed => fixture.Create<StopGoPenaltyServedEvent>(),
			EventType.Flashback => fixture.Create<FlashbackEvent>(),
			EventType.ButtonStatus => fixture.Create<ButtonsEvent>(),
			EventType.Overtake => fixture.Create<OvertakeEvent>(),
			_ => null,
		};

		var packet = BuildPacket<EventDataPacket>()
			.With(x => x.EventDetails, eventDetails)
			.With(x => x.EventType, eventType)
			.Create();

		var bytes = new byte[EventDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadFinalClassificationDataPacket()
	{
		var classificationData = fixture.Build<FinalClassificationData>()
			.With(x => x.TyreStintsActual, () => fixture.CreateMany<ActualCompound>(8).ToArray())
			.With(x => x.TyreStintsVisual, () => fixture.CreateMany<VisualCompound>(8).ToArray())
			.With(x => x.TyreStintsEndLaps, () => fixture.CreateMany<byte>(8).ToArray())
			.CreateMany(22)
			.ToArray();

		var packet = BuildPacket<FinalClassificationDataPacket>()
			.With(x => x.ClassificationData, classificationData)
			.Create();

		var bytes = new byte[FinalClassificationDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadLapDataPacket()
	{
		var packet = BuildPacket<LapDataPacket>()
			.With(x => x.LapData, fixture.CreateMany<LapData>(22).ToArray())
			.Create();

		var bytes = new byte[LapDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadLobbyInfoDataPacket()
	{
		var packet = BuildPacket<LobbyInfoDataPacket>()
			.With(x => x.LobbyPlayers, fixture.CreateMany<LobbyInfoData>(22).ToArray())
			.Create();

		var bytes = new byte[LobbyInfoDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadMotionDataPacket()
	{
		var packet = BuildPacket<MotionDataPacket>()
			.With(x => x.CarMotionData, fixture.CreateMany<CarMotionData>(22).ToArray())
			.Create();

		var bytes = new byte[MotionDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadMotionExDataPacket()
	{
		var packet = BuildPacket<MotionExDataPacket>()
			.Create();

		var bytes = new byte[MotionExDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadParticipantsDataPacket()
	{
		var packet = BuildPacket<ParticipantsDataPacket>()
			.With(x => x.Participants, fixture.CreateMany<ParticipantData>(22).ToArray())
			.Create();

		var bytes = new byte[ParticipantsDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadSessionDataPacket()
	{
		var packet = BuildPacket<SessionDataPacket>()
			.With(x => x.MarshalZones, fixture.CreateMany<MarshalZone>(21).ToArray())
			.With(x => x.WeatherForecastSamples, fixture.CreateMany<WeatherForecastSample>(56).ToArray())
			.Create();

		var bytes = new byte[SessionDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadTyreSetsDataPacket()
	{
		var packet = BuildPacket<TyreSetsDataPacket>()
			.With(x => x.TyreSetDatas, fixture.CreateMany<TyreSetData>(20).ToArray())
			.Create();

		var bytes = new byte[TyreSetsDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.WriteObject(packet);

		var actualPacket = bytes.ToPacket();
		actualPacket.Should().BeEquivalentTo(packet);
	}

	IPostprocessComposer<T> BuildPacket<T>() where T : IPacket, new()
	{
		var packetType = new T() switch
		{
			CarDamageDataPacket => PacketType.CarDamage,
			CarSetupDataPacket => PacketType.CarSetups,
			CarStatusDataPacket => PacketType.CarStatus,
			CarTelemetryDataPacket => PacketType.CarTelemetry,
			EventDataPacket => PacketType.Event,
			FinalClassificationDataPacket => PacketType.FinalClassification,
			LapDataPacket => PacketType.LapData,
			LobbyInfoDataPacket => PacketType.LobbyInfo,
			MotionDataPacket => PacketType.Motion,
			MotionExDataPacket => PacketType.MotionEx,
			ParticipantsDataPacket => PacketType.Participants,
			SessionDataPacket => PacketType.Session,
			SessionHistoryDataPacket => PacketType.SessionHistory,
			TyreSetsDataPacket => PacketType.TyreSets,
			_ => throw new NotImplementedException()
		};

		var header = fixture.Build<PacketHeader>().With(x => x.PacketType, packetType)
			.Create();

		return fixture.Build<T>()
			.With(x => x.Header, header);
	}
}
