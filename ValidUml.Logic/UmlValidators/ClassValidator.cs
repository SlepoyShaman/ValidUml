﻿using System.Xml;
using ValidUml.Logic.Models.UsersRules;
using ValidUml.Logic.UmlParsers;
using ValidUml.Logic.UmlValidators.Filters;
using ValidUml.Logic.UmlValidators.RuleValidators;

namespace ValidUml.Logic.UmlValidators
{
	internal class ClassValidator
	{
		private readonly ClassDiagram _diagram;
		public ClassValidator(ClassDiagram diagram)
		{
			_diagram = diagram;
		}

		public ValidationResult Validate(ClassRule rule)
		{
			var errors = new List<string>();
			var entities = Filter(rule);
			var validators = rule.Rules.Select(r => GetValidator(r));
			foreach (var entity in entities)
			{
				var fails = validators.Select(v => v.Validate(entity))
					.Where(e => e is not null);
				errors.AddRange(fails!);
			}

			return new(errors.Count == 0, rule.Name, [.. errors]);
		}

		private IEnumerable<XmlNode> Filter(ClassRule rule)
		{
			var entities = rule.EntityType switch
			{
				EntityType.All => _diagram.AllEntities(),
				EntityType.Class => _diagram.GetClasses(),
				EntityType.Interface => _diagram.GetInterfases(),
				_ => throw new Exception("Неизвестный тип сущности")
			};

			return rule.FilterType switch
			{
				FilterType.Name => NameFilter.Execute(entities, rule.FilterValue),
				_ => throw new Exception("Неизвестный тип фильтрации")
			};
		}

		private IRuleValidator GetValidator(EntityRule rule)
		{
			return rule.RuleType switch
			{
				EntityRuleType.ContainsProperties => new ContainsPropertiesValidator(rule.RuleValue),
				EntityRuleType.ContainsMethods => new ContainsMethodsValidator(rule.RuleValue),
				EntityRuleType.NotContainsProperties => new NotContainsPropertiesValidator(rule.RuleValue),
				EntityRuleType.NotContainsMethods => new NotContainsMethodsValidator(rule.RuleValue),
				_ => throw new Exception("Неизвестный тип валидации")
			};
		}
	}
}
