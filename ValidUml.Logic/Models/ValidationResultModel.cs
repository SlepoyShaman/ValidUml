using ValidUml.Logic.UmlValidators;

namespace ValidUml.Logic.Models
{
	public record ValidationResultModel(bool TotalValid, ValidationResult[] Results)
	{
		public static ValidationResultModel Create(IEnumerable<ValidationResult> results)
		{
			var total = results.Select(r => r.IsValid).Aggregate((acc, cur) => acc && cur);
			return new ValidationResultModel(total, [.. results]);
		}
	}

}
