using System.Diagnostics.CodeAnalysis;

using Microsoft.CodeAnalysis;

namespace F1Game.UDP.SourceGenerator;

[SuppressMessage("MicrosoftCodeAnalysisReleaseTracking", "RS2008:Enable analyzer release tracking", Justification = "Internal project, release tracking not required")]
static class DiagnosticDescriptors
{
	public static readonly DiagnosticDescriptor TypeMustBePartial = new(
		id: "F1GUSG001",
		title: "Type must be partial",
		messageFormat: "Type '{0}' must be declared as partial",
		category: "Usage",
		defaultSeverity: DiagnosticSeverity.Error,
		isEnabledByDefault: true);

	public static readonly DiagnosticDescriptor NoMoreThanOneAttribute = new(
		id: "F1GUSG002",
		title: "Only one attribute is allowed",
		messageFormat: "Only one attribute is allowed on the partial struct '{0}'",
		category: "Usage",
		defaultSeverity: DiagnosticSeverity.Error,
		isEnabledByDefault: true);

	public static readonly DiagnosticDescriptor LengthShouldBePositiveNumber = new(
		id: "F1GUSG003",
		title: "Length should be a positive number",
		messageFormat: "Length should be a positive number on the partial struct '{0}'",
		category: "Usage",
		defaultSeverity: DiagnosticSeverity.Error,
		isEnabledByDefault: true);

	public static readonly DiagnosticDescriptor TooManyInstanceFields = new(
		id: "F1GUSG004",
		title: "Too many instance fields",
		messageFormat: "Too many instance fields on the partial struct '{0}'",
		category: "Usage",
		defaultSeverity: DiagnosticSeverity.Error,
		isEnabledByDefault: true);

	public static readonly DiagnosticDescriptor InstanceFieldAndElementTypeArePresent = new(
		id: "F1GUSG005",
		title: "Instance field and element type are both present",
		messageFormat: "Instance field and element type are both present on the partial struct '{0}'",
		category: "Usage",
		defaultSeverity: DiagnosticSeverity.Error,
		isEnabledByDefault: true);

	public static readonly DiagnosticDescriptor NoTypeForInstanceField = new(
		id: "F1GUSG006",
		title: "No type for instance field",
		messageFormat: "No type for instance field on the partial struct '{0}'",
		category: "Usage",
		defaultSeverity: DiagnosticSeverity.Error,
		isEnabledByDefault: true);
}
