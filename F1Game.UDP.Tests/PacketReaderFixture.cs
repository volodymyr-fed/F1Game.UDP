using AutoFixture;
using AutoFixture.Dsl;

using F1Game.UDP.Data;
using F1Game.UDP.Enums;
using F1Game.UDP.Events;
using F1Game.UDP.Internal;
using F1Game.UDP.Packets;

namespace F1Game.UDP.Tests;

[FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
sealed class PacketReaderFixture
{
	readonly Fixture fixture = new();

	[Test]
	public void ToPacket_WithNotEnoughBytes_ThrowsNotEnoughBytesException()
	{
		byte[] bytes = []; // Not enough bytes for any packet

		Action act = () => bytes.ToPacket();

		act.Should().Throw<NotEnoughBytesException>()
			.Which.TypeToParse.Should().Be(typeof(PacketHeader));
	}

	[Test]
	public void ToPacket_WithInvalidPacketType_ThrowsInvalidPacketTypeException()
	{
		var bytes = new byte[PacketHeader.Size];
		bytes[PacketHeader.PacketTypeIndex] = 255; // Invalid packet type

		Action act = () => bytes.ToPacket();

		act.Should().Throw<InvalidPacketTypeException>()
			.Which.PacketType.Should().Be((PacketType)255);
	}

	[TestCase(PacketType.Motion, typeof(MotionDataPacket))]
	[TestCase(PacketType.Session, typeof(SessionDataPacket))]
	[TestCase(PacketType.LapData, typeof(LapDataPacket))]
	[TestCase(PacketType.Event, typeof(EventDataPacket))]
	[TestCase(PacketType.Participants, typeof(ParticipantsDataPacket))]
	[TestCase(PacketType.CarSetups, typeof(CarSetupDataPacket))]
	[TestCase(PacketType.CarTelemetry, typeof(CarTelemetryDataPacket))]
	[TestCase(PacketType.CarStatus, typeof(CarStatusDataPacket))]
	[TestCase(PacketType.FinalClassification, typeof(FinalClassificationDataPacket))]
	[TestCase(PacketType.LobbyInfo, typeof(LobbyInfoDataPacket))]
	[TestCase(PacketType.CarDamage, typeof(CarDamageDataPacket))]
	[TestCase(PacketType.SessionHistory, typeof(SessionHistoryDataPacket))]
	[TestCase(PacketType.TyreSets, typeof(TyreSetsDataPacket))]
	[TestCase(PacketType.MotionEx, typeof(MotionExDataPacket))]
	[TestCase(PacketType.TimeTrial, typeof(TimeTrialDataPacket))]
	public void ToPacket_ThrowsNotEnoughBytesException(PacketType packetType, Type expectedType)
	{
		byte[] bytes = new byte[PacketHeader.Size];
		bytes[PacketHeader.PacketTypeIndex] = (byte)packetType;

		Action act = () => bytes.ToPacket();

		// Assert
		act.Should().Throw<NotEnoughBytesException>()
			.Which.TypeToParse.Should().Be(expectedType);
	}

	[Test]
	public void ReadCarDamageDataPacket()
	{
		UnionPacket packet = BuildPacket<CarDamageDataPacket>()
			.With(x => x.CarDamageData, fixture.CreateMany<CarDamageData>(22).ToArray22())
			.Create();

		var bytes = new byte[CarDamageDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadCarSetupDataPacket()
	{
		UnionPacket packet = BuildPacket<CarSetupDataPacket>()
			.With(x => x.CarSetups, fixture.CreateMany<CarSetupData>(22).ToArray22())
			.Create();

		var bytes = new byte[CarSetupDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadCarStatusDataPacket()
	{
		UnionPacket packet = BuildPacket<CarStatusDataPacket>()
			.With(x => x.CarStatusData, fixture.CreateMany<CarStatusData>(22).ToArray22())
			.Create();

		var bytes = new byte[CarStatusDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadCarTelemetryDataPacket()
	{
		UnionPacket packet = BuildPacket<CarTelemetryDataPacket>()
			.With(x => x.CarTelemetryData, fixture.CreateMany<CarTelemetryData>(22).ToArray22())
			.Create();

		var bytes = new byte[CarTelemetryDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
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
	[TestCase(EventType.SafetyCar)]
	[TestCase(EventType.Collision)]
	public void ReadEventDataPacket(EventType eventType)
	{
		EventDetails eventDetails = eventType switch
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
			EventType.SafetyCar => fixture.Create<SafetyCarEvent>(),
			EventType.Collision => fixture.Create<CollisionEvent>(),
			_ => new EventDetails { EventType = eventType },
		};

		UnionPacket packet = BuildPacket<EventDataPacket>()
			.With(x => x.EventDetails, eventDetails)
			.Create();

		var bytes = new byte[EventDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadFinalClassificationDataPacket()
	{
		var classificationData = fixture.Build<FinalClassificationData>()
			.With(x => x.TyreStintsActual, () => fixture.CreateMany<ActualCompound>(8).ToArray8())
			.With(x => x.TyreStintsVisual, () => fixture.CreateMany<VisualCompound>(8).ToArray8())
			.With(x => x.TyreStintsEndLaps, () => fixture.CreateMany<byte>(8).ToArray8())
			.CreateMany(22)
			.ToArray22();

		UnionPacket packet = BuildPacket<FinalClassificationDataPacket>()
			.With(x => x.ClassificationData, classificationData)
			.Create();

		var bytes = new byte[FinalClassificationDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadLapDataPacket()
	{
		UnionPacket packet = BuildPacket<LapDataPacket>()
			.With(x => x.LapData, fixture.CreateMany<LapData>(22).ToArray22())
			.Create();

		var bytes = new byte[LapDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadLobbyInfoDataPacket()
	{
		var lobbyPlayers = fixture.Build<LobbyInfoData>()
			.With(x => x.NameBytes, fixture.Create<string>().AsArray48Bytes())
			.CreateMany(22)
			.ToArray22();

		UnionPacket packet = BuildPacket<LobbyInfoDataPacket>()
			.With(x => x.LobbyPlayers, lobbyPlayers)
			.Create();

		var bytes = new byte[LobbyInfoDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadMotionDataPacket()
	{
		UnionPacket packet = BuildPacket<MotionDataPacket>()
			.With(x => x.CarMotionData, fixture.CreateMany<CarMotionData>(22).ToArray22())
			.Create();

		var bytes = new byte[MotionDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadMotionExDataPacket()
	{
		UnionPacket packet = BuildPacket<MotionExDataPacket>()
			.Create();

		var bytes = new byte[MotionExDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadParticipantsDataPacket()
	{
		var participants = fixture.Build<ParticipantData>()
			.With(x => x.NameBytes, fixture.Create<string>().AsArray48Bytes())
			.CreateMany(22)
			.ToArray22();

		UnionPacket packet = BuildPacket<ParticipantsDataPacket>()
			.With(x => x.Participants, participants)
			.Create();

		var bytes = new byte[ParticipantsDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadSessionDataPacket()
	{
		UnionPacket packet = BuildPacket<SessionDataPacket>()
			.With(x => x.MarshalZones, fixture.CreateMany<MarshalZone>(21).ToArray21())
			.With(x => x.WeatherForecastSamples, fixture.CreateMany<WeatherForecastSample>(64).ToArray64())
			.With(x => x.WeekendStructure, fixture.CreateMany<SessionType>(12).ToArray12())
			.Create();

		var bytes = new byte[SessionDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadSessionHistoryDataPacket()
	{
		UnionPacket packet = BuildPacket<SessionHistoryDataPacket>()
			.With(x => x.LapHistoryData, fixture.CreateMany<LapHistoryData>(100).ToArray100())
			.With(x => x.TyreStintsHistoryData, fixture.CreateMany<TyreStintHistoryData>(8).ToArray8())
			.Create();

		var bytes = new byte[SessionHistoryDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadTyreSetsDataPacket()
	{
		UnionPacket packet = BuildPacket<TyreSetsDataPacket>()
			.With(x => x.TyreSetDatas, fixture.CreateMany<TyreSetData>(20).ToArray20())
			.Create();

		var bytes = new byte[TyreSetsDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	[Test]
	public void ReadTimeTrialDataPacket()
	{
		UnionPacket packet = BuildPacket<TimeTrialDataPacket>().Create();

		var bytes = new byte[TimeTrialDataPacket.Size];
		var writer = new BytesWriter(bytes);
		writer.Write(packet);

		bytes.ToPacket().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithReader().Should().BeEquivalentTo(packet);
		bytes.ToPacketWithMarshal().Should().BeEquivalentTo(packet);
	}

	IPostprocessComposer<T> BuildPacket<T>() where T : IHaveHeader, new()
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
			TimeTrialDataPacket => PacketType.TimeTrial,
			_ => throw new NotImplementedException()
		};

		var header = fixture.Build<PacketHeader>().With(x => x.PacketType, packetType)
			.Create();

		return fixture.Build<T>()
			.With(x => x.Header, header);
	}
}
