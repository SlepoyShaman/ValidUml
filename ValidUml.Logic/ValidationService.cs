using ValidUml.Logic.Models;
using ValidUml.Logic.Models.UsersRules;
using ValidUml.Logic.UmlParsers;
using ValidUml.Logic.UmlValidators;

namespace ValidUml.Logic
{
	public static class ValidationService
	{
		public static ValidationResultModel ValidateClassDiagram(UserInputModel<ClassRule> model)
		{
			var diagram = new ClassDiagram(model.XmlString);
			var validator = new ClassValidator(diagram);
			var results = model.Rules.Select(validator.Validate);
			return ValidationResultModel.Create(results);
		}
	}
}
