﻿using Obsidian.Serialization.Attributes;

namespace Obsidian.Net.Packets.Play.Clientbound;

public partial class MoveEntityPosPacket
{
    [Field(0), VarLength]
    public int EntityId { get; init; }

    [Field(1), DataFormat(typeof(short))]
    public Vector Delta { get; init; }

    [Field(4)]
    public bool OnGround { get; init; }

    public override void Serialize(INetStreamWriter writer)
    {
        writer.WriteVarInt(this.EntityId);
        writer.WriteAbsoluteShortPosition(this.Delta);
        writer.WriteBoolean(this.OnGround);
    }
}
