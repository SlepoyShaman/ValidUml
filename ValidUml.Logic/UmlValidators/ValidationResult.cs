namespace ValidUml.Logic.UmlValidators
{
	public record ValidationResult(bool IsValid, string RuleName, string[] Errors);
}
