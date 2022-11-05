using MVC_Curso.Context;

namespace MVC_Curso.Models {
    public class CarrinhoCompra {

        private readonly AppDbContext _context;

        //injeta o contexto no construtor
        public CarrinhoCompra(AppDbContext contexto) {
            _context = contexto;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItems { get; set; }


        public static CarrinhoCompra GetCarrinho(IServiceProvider services) {

            //define uma sessão
            ISession session = 
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            //obtem um serviço do tipo do nosso contexto
            var context = services.GetService<AppDbContext>();

            //obtem ou gera o id do carrinho
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            //atribui o id do carrinho na Sessão
            session.SetString("CarrinhoId", carrinhoId);

            //retorna o carrinho com o contexto e o Id atribuído ou obtido
            return new CarrinhoCompra(context) {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Lanche lanche) {

            //verifica se o lanche a ser incluido já está na tabela CarrinhoCompraItens
            var carrinhoCompraItem = _context.CarrinhoCompraItens.SingleOrDefault(
                s => s.Lanche.LancheId == lanche.LancheId &&
                s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null) {
                carrinhoCompraItem = new CarrinhoCompraItem {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Lanche = lanche,
                    Quantidade = 1
                };
                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else {
                carrinhoCompraItem.Quantidade++;
            }
            _context.SaveChanges();
        }


    }
}
