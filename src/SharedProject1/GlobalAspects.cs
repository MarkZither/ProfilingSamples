using PostSharp.Patterns.Diagnostics;
using PostSharp.Extensibility;
using WebApi.To.Profile;

[assembly: MiniProfilerStep(AttributeTargetTypes = "*Class*", AttributeTargetMemberAttributes = MulticastAttributes.Public)]
[assembly: MiniProfilerStep(AttributeTargetTypes = "*Controller", AttributeTargetMemberAttributes = MulticastAttributes.Public)]