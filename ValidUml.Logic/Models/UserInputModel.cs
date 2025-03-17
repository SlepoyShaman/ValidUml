namespace ValidUml.Logic.Models
{
	public record UserInputModel<T>(
		string XmlString,
		T[] Rules) where T : IUserRule;
}
