using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Webmall.Model.Database.DataLayer;
using Webmall.Model.Database.DataLayer.Models;
using Webmall.Model.Entities.User;
using Webmall.Model.Repositories.Abstract;

namespace Webmall.Model.Database.Repositories
{
    public class PresentationRepository : IPresentationRepository
    {
        private readonly IMapper _mapper;

        public PresentationRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void AddRepresentation(int userId, string clientCode, bool accepted, long roles)
        {
            using (var db = new WebmallDbContext())
            {
                //if (string.IsNullOrWhiteSpace(clientCode))
                //    return ViewRes.SharedResources.TaxCodeIsEmpty;

                //var client = _vdb.vsspGetClientInfo(clientCode).FirstOrDefault();

                //if (client != null)
                //{
                var dbItem = new DbClientPresenter
                {
                    UserId = userId,
                    ClientId = clientCode,
                    IsAccepted = accepted,
                    Roles = roles
                };
                db.ClientPresenters.Add(dbItem);
                db.SaveChanges();
            }
        }

        public ClientPresenter ApproveRepresentation(int id)
        {
            using (var db = new WebmallDbContext())
            {
                var clientPresenter = db.ClientPresenters.Include(i=>i.User).FirstOrDefault(i => i.Id == id);
                if (clientPresenter != null)
                {
                    clientPresenter.IsAccepted = true;
                    db.SaveChanges();
                    return _mapper.Map<ClientPresenter>(clientPresenter);
                }
            }

            return null;
        }

        public long ChangeRepresentationRole(int id, string role, bool set)
        {
            using (var db = new WebmallDbContext())
            {
                var presenter = db.ClientPresenters.FirstOrDefault(i => i.Id == id);
                if (presenter != null)
                {
                    presenter.Roles = presenter.Roles.SetFlag((long)Enum.Parse(typeof(RepresentativeRole), role), set);
                    db.SaveChanges();
                    return presenter.Roles;
                }
                return 0;
            }
        }

        public ClientPresenter GetClientPresenter(int id)
        {
            using (var db = new WebmallDbContext())
            {
                return _mapper.Map<ClientPresenter>(db.ClientPresenters.Include(i => i.User).FirstOrDefault(i => i.Id == id));
            }
        }

        public List<ClientPresenter> GetPresentationsList(string clientId)
        {
            using (var db = new WebmallDbContext())
            {
                var result = _mapper.Map<List<ClientPresenter>>(db.ClientPresenters.Include(i=>i.User).Where(i => i.ClientId == clientId));
                return result;
            }
        }

        public ClientPresenter RemoveRepresentation(int id)
        {
            using (var db = new WebmallDbContext())
            {
                var pres = db.ClientPresenters.Include(i=>i.User).FirstOrDefault(i => i.Id == id);
                
                if (pres != null)
                {
                    // Если удаляется текущее представительство пользователя, надо его сменить на другое
                    if (pres.User.CurrentPresentation == pres)
                    {
                        pres.User.CurrentPresentation = pres.User.Presentations.FirstOrDefault(i => i.Id != id);
                    }

                    var clientPresenter = _mapper.Map<ClientPresenter>(pres);

                    db.ClientPresenters.Remove(pres);
                    db.SaveChanges();

                    return clientPresenter;
                }
            }

            return null;
        }

        public void SavePresentationRequest(User user, ClientPresenter request)
        {
            using (var db = new WebmallDbContext())
            {
                var dbUser = db.Users.FirstOrDefault(i => i.Login == user.Login);
                var dbPresentation = new DbClientPresenter
                {
                    ClientId = request.Client.Id,
                    IsAccepted = false,
                    Roles = request.Roles,
                    UserId = user.Id
                };
                dbUser?.Presentations.Add(dbPresentation);
            }
        }
    }
}
