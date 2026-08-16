# GoodnightAstm 🩸

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![C#](https://img.shields.io/badge/C%23-8.0-blue.svg)](#)

A clean-room **ASTM E1394 (LIS2-A2) parser** for .NET — born during one of those
countless sleepless nights spent connecting laboratory instruments to a LIS.

ASTM E1394 is the de-facto standard protocol for exchanging test orders and
results between **laboratory analyzers** and a **Laboratory Information
System (LIS)**. If you write software that has to talk to a blood analyzer,
immunology instrument, or any piece of clinical-lab hardware, this is the
message format you meet at the serial port or TCP socket.

## What it does

`AstmParser.cs` parses a raw ASTM message into a **typed object tree** — every
frame becomes a first-class record you can navigate instead of fiddling with
pipe-delimited strings:

| Record | Meaning |
|--------|---------|
| `H` Header | message framing, sender/receiver |
| `P` Patient | patient demographics |
| `O` Order | test order |
| `R` Result | test result |
| `C` Comment | free-text comment |
| `M` Manufacturer | vendor-specific data |
| `L` Terminator | message trailer |

Abstract base class `ASTM_Record` exposes a uniform API — `fieldName(idx)`,
`fieldValue(idx)`, `fieldsCount()`, `comments()`, `manufacturerInfo()` — so
consumers can walk any record generically, including nested comments and
manufacturer info.

## Why it exists

> *"As I had to connect a customer's device to an LIS I found out there are no
> really usable tools for analysing and debugging ASTM E1394. Some commercial
> tools I got for evaluation were old, bad, vendor-specific, expensive — or
> (mostly) all of these together."*

GoodnightAstm is the reference implementation behind that pain point: small,
readable, license-clean, and easy to embed.

## Companion project

This is the parser-only sibling of **[ASTMViewer](../ASTMViewer)** — a WinForms
GUI that loads ASTM messages and renders them as an inspectable object tree
(my most-starred project, 23 ⭐). Use GoodnightAstm when you need the parsing
logic, ASTMViewer when you want to *see* what a message contains.

## Usage

```csharp
// Parse a frame and walk the tree
ASTM_Record record = ...;
for (int i = 1; i <= record.fieldsCount(); i++)
    Console.WriteLine($"{record.fieldName(i)} = {record.fieldValue(i)}");
```

## Requirements

- .NET / C# (Visual Studio solution or your favourite editor)

## Build

```bash
msbuild *.sln /p:Configuration=Release
```

## License

[MIT](LICENSE) © Valentin Heinitz
