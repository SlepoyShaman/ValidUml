namespace ValidUml.Logic.Models.UsersRules
{
	public record ClassRule(
		string Name,
		EntityType EntityType,
		FilterType FilterType,
		string FilterValue,
		EntityRule[] Rules) : IUserRule;

	public record EntityRule(
		EntityRuleType RuleType,
		string RuleValue);

	public enum EntityType
	{
		Class,
		Interface,
		All
	}

	public enum FilterType
	{
		Name,
		Implementing,
		ChildsOf
	}

	public enum EntityRuleType
	{
		ContainsProperties,
		NotContainsProperties,
		ContainsMethods,
		NotContainsMethods,
		HasName,
		Implements,
		ChildOf
	}


}
