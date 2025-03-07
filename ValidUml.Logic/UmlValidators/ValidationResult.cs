namespace ValidUml.Logic.UmlValidators
{
	internal record ValidationResult(bool IsValid, string RuleName, string[] Errors);
}
