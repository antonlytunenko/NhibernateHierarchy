using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace Hierarchy.NHibernate.Tests
{
	[TestClass]
	public class NHibernateVehicleRepositoryTest
	{
		private const int ITEMS_COUNT = 5;
		private IVehicleRepository _repo;

		[TestInitialize]
		public void Init()
		{
			var conStr = ConfigurationManager.ConnectionStrings["test"].ConnectionString;
			_repo = new NHibernateVihicleRepository(NHibernateHelper.GetSession(conStr));
			SeedData(ITEMS_COUNT);
		}

		[TestCleanup]
		public void CleanUp()
		{
			ClearAll();
		}

		[TestMethod]
		public void GetAll_Bicycles()
		{
			AssertVehicles<Bicycle>();
		}

		[TestMethod]
		public void GetAll_Motors()
		{
			AssertVehicles<MotorVehicle>(ITEMS_COUNT*3);
		}

		[TestMethod]
		public void GetAll_Cars()
		{
			AssertVehicles<Car>();
		}

		[TestMethod]
		public void GetAll_Buses()
		{
			AssertVehicles<Bus>();
		}

		[TestMethod]
		public void GetAll_Trucks()
		{
			AssertVehicles<Truck>();
		}

		private void AssertVehicles<T>(int expCount = ITEMS_COUNT) where T: Vehicle
		{
			var vehicles = Get<T>();
			Assert.AreEqual(expCount, vehicles.Count);
		}

		private IList<T> Get<T>() where T: Vehicle
		{
			return _repo.GetAll<T>().ToList();
		}

		private void SeedData(int count)
		{
			CreateBicycles(count);
			CreateCars(count);
			CreateTrucks(count);
			CreateBuses(count);
		}

		private void ClearAll()
		{
			var all = _repo.GetAll<Vehicle>().ToList();
			all.ForEach(v => _repo.Delete(v));
		}

		private void CreateBicycles(int count)
		{
			for (var i = 0; i < count; i++)
			{				
				_repo.Save(FillVehicle(new Bicycle
				{
					FrameProducer = "test prod" + i
				}, i));
			}
		}

		private void CreateCars(int count)
		{
			for (var i = 0; i < count; i++)
			{
				_repo.Save(FillVehicle(FillMotor(new Car
				{
					CarTypeId = i
				}, i),i));
			}
		}

		private void CreateTrucks(int count)
		{
			for (var i = 0; i < count; i++)
			{
				_repo.Save(FillVehicle(FillMotor(new Truck
				{
					GVWR = 500*i
				}, i), i));
			}
		}

		private void CreateBuses(int count)
		{
			for (var i = 0; i < count; i++)
			{
				_repo.Save(FillVehicle(FillMotor(new Bus
				{
					DecksCount = 1,
					Capacity = 5*i
				}, i), i));
			}
		}

		private Vehicle FillVehicle(Vehicle v, int i)
		{
			v.Mark = "test mark" + i;
			v.Model = "test model" + i;
			v.ProductionDate = DateTime.Now.AddMonths(-1 * i);
			v.Weight = 3 * i + 5;
			return v;
		}

		private Vehicle FillMotor(MotorVehicle v, int i)
		{
			v.ValvesNumber = 16;
			v.MotorVolume = i * 0.3 + 0.5;
			return v;
		}
	}
}
