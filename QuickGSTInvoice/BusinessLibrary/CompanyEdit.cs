using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Csla;
using Csla.Rules;

namespace BusinessLibrary
{
  [Serializable]
  public class CompanyEdit : BusinessBase<CompanyEdit>
  {
    public static readonly PropertyInfo<Guid> IdProperty = RegisterProperty<Guid>(nameof(Id));
    public Guid Id
    {
      get { return GetProperty(IdProperty); }
      set { SetProperty(IdProperty, value); }
    }

    public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
    [Required]
    public string Name
    {
      get { return GetProperty(NameProperty); }
      set { SetProperty(NameProperty, value); }
    }
        public static readonly PropertyInfo<string> CodeProperty = RegisterProperty<string>(nameof(Code));
        public string Code
        {
            get => GetProperty(CodeProperty);
            set => SetProperty(CodeProperty, value);
        }

        protected override void AddBusinessRules()
    {
      base.AddBusinessRules();
      BusinessRules.AddRule(new InfoText(NameProperty, "Company name (required)"));
      BusinessRules.AddRule(new CheckCase(NameProperty));
      BusinessRules.AddRule(new NoZAllowed(NameProperty));
    }
    
    [RunLocal]
    [Create]
    private void Create()
    {
       Id = Guid.NewGuid();
      BusinessRules.CheckRules();
    }
        [RunLocal]
        [Fetch]
    private void Fetch(Guid id, [Inject]DataAccess.ICompanyDal dal)
    {
      var data = dal.Get(id);
      using (BypassPropertyChecks)
        Csla.Data.DataMapper.Map(data, this);
      BusinessRules.CheckRules();
    }
        [RunLocal]

        [Insert]
    private void Insert([Inject]DataAccess.ICompanyDal dal)
    {
      using (BypassPropertyChecks)
      {
                var data = new DataAccess.CompanyEntity
                {
                    Code = Code,
                    Name = Name
                };
        var result = dal.Insert(data);
        Id = result.Id;
      }
    }
        [RunLocal]

        [Update]
    private void Update([Inject]DataAccess.ICompanyDal dal)
    {
      using (BypassPropertyChecks)
      {
        var data = new DataAccess.CompanyEntity
        {
          Id = Id,
          Name = Name
        };
        dal.Update(data);
      }
    }
        [RunLocal]
        [DeleteSelf]
    private void DeleteSelf([Inject]DataAccess.ICompanyDal dal)
    {
      Delete(ReadProperty(IdProperty), dal);
    }
        [RunLocal]

        [Delete]
    private void Delete(Guid id, [Inject]DataAccess.ICompanyDal dal)
    {
      dal.Delete(id);
    }

  }
}
