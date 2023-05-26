using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class SocialMediaManager : ISocialMedialService
	{
		ISocialMediaDal _socialMedialService;

		public SocialMediaManager(ISocialMediaDal socialMedialService)
		{
			_socialMedialService = socialMedialService;
		}

		public void Delete(SocialMedia t)
		{
			_socialMedialService.Delete(t);
		}

		public SocialMedia GetById(int id)
		{
			return _socialMedialService.GetById(id);
		}

		public List<SocialMedia> GetListAll()
		{
			return _socialMedialService.GetListAll();
		}

		public void Insert(SocialMedia t)
		{
			_socialMedialService.Insert(t);
		}

		public void Update(SocialMedia t)
		{
			_socialMedialService.Update(t);
		}
	}
}
