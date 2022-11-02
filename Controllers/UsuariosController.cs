using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {

        public IActionResult ListarUsuarios()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificarSeUsuarioEAdmin(this);
           
                
                 return View(new UsuarioService().Listar());
        }


        public IActionResult NeedAdmin()
        {
            return View();
        }

        public IActionResult RegistrarUsuarios()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificarSeUsuarioEAdmin(this);

            return View();

        }
        [HttpPost]
        public IActionResult RegistrarUsuarios(Usuario novoUser)
        {
            novoUser.Senha = Criptografo.TextoCriptografado(novoUser.Senha);
            new UsuarioService().incluirUsuario(novoUser);

            return RedirectToAction("ListarUsuarios");
        }

        public IActionResult EditarUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificarSeUsuarioEAdmin(this);
            return View(new UsuarioService().buscarPorId(id));

        }
        [HttpPost]
        public IActionResult EditarUsuario(Usuario userEditado)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificarSeUsuarioEAdmin(this);


            new UsuarioService().editarUsuario(userEditado);
            return RedirectToAction("ListarUsuarios");

        }
        public IActionResult ExcluirUsuario(int id)
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificarSeUsuarioEAdmin(this);
           new UsuarioService().excluirUsuario(id);
            return RedirectToAction("ListarUsuarios");

        }



    }
}