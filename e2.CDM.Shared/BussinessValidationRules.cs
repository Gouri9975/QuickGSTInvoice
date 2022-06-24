using Csla.Core;
using Csla.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace e2.CDM.Lib
{
  public class BussinessValidationRules
  {
    // add dependency for LessThanProperty rule on Num1
    //BusinessRules.AddRule(new Dependency(Num2Property, Num1Property));
    //BusinessRules.AddRule(new LessThanProperty(Num1Property, Num2Property));
    public class LessThanProperty : BusinessRule
    {
      private IPropertyInfo CompareTo { get; set; }

      /// <summary>
      /// Initializes a new instance of the <see cref="LessThanProperty"/> class.
      /// </summary>
      /// <param name="primaryProperty">The primary property.</param>
      /// <param name="compareToProperty">The compare to property.</param>
      public LessThanProperty(IPropertyInfo primaryProperty, IPropertyInfo compareToProperty)
        : base(primaryProperty)
      {
        CompareTo = compareToProperty;

        if (InputProperties == null)
        {
          InputProperties = new List<IPropertyInfo>();
        }
        InputProperties.Add(primaryProperty);
        InputProperties.Add(compareToProperty);
      }

      /// <summary>
      /// Does the check for primary propert less than compareTo property
      /// </summary>
      /// <param name="context">Rule context object.</param>
      protected override void Execute(IRuleContext context)
      {
        var value1 = (dynamic)context.InputPropertyValues[PrimaryProperty];
        var value2 = (dynamic)context.InputPropertyValues[CompareTo];

        if (value1 > value2)
        {
          context.AddErrorResult(string.Format("{0} must be less than or equal {1}", PrimaryProperty.FriendlyName, CompareTo.FriendlyName));
        }
      }
    }


    //// set up dependencies to that Sum is automatially recaclulated when PrimaryProperty is changed \
    //BusinessRules.AddRule(new Dependency(Num1Property, SumProperty));
    //BusinessRules.AddRule(new Dependency(Num2Property, SumProperty));

    // calculates sum rule - must alwas run before MinValue with lower priority
    //    BusinessRules.AddRule(new CalcSum(SumProperty, Num1Property, Num2Property) { Priority = -1});

    public class CalcSum : BusinessRule
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="CalcSum"/> class.
      /// </summary>
      /// <param name="primaryProperty">The primary property.</param>
      /// <param name="inputProperties">The input properties.</param>
      public CalcSum(IPropertyInfo primaryProperty, params IPropertyInfo[] inputProperties)
        : base(primaryProperty)
      {
        if (InputProperties == null)
        {
          InputProperties = new List<IPropertyInfo>();
        }
        InputProperties.AddRange(inputProperties);
      }

      protected override void Execute(IRuleContext context)
      {
        // Use linq Sum to calculate the sum value 
        var sum = context.InputPropertyValues.Sum(property => (dynamic)property.Value);

        // add calculated value to OutValues 
        // When rule is completed the RuleEngig will update businessobject
        context.AddOutValue(PrimaryProperty, sum);
      }
    }



  }
}
