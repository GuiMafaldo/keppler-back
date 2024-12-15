using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Context;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("[controller]")]
public class AdminController : ControllerBase
{
    private readonly AdminContext _context;

    public AdminController(AdminContext context)
    {
        _context = context;
    }

                // === ADMINISTRADOR LOGIN ===
    [HttpPost("login")]
    public async Task<IActionResult> LoginApp([FromBody]Administracao login)
    {
        var userCredentials = await _context.Administracao.SingleOrDefaultAsync(userLogin => userLogin.Username == login.Username);

        if(userCredentials == null || userCredentials.Password != login.Password)
        {
            return BadRequest(new
            {
                success = false,
                message = "Usuario ou senha invalidos, Verifique suas credenciais de acesso."
            });
        } 
        
            return Ok(new 
                { 
                    success = true, 
                    message = "Login efetuado com sucesso.", 
                    user = new 
                    {
                        id = userCredentials.Id,
                        username = userCredentials.Username
                    }                                 
                }
            );      
    }

                                            // === CLIENTES ===

    // ------------------------------------------- CADASTRA CLIENTE ---------------------------------------//
    [HttpPost("cliente")]
    public async Task<IActionResult> CadastrarCliente([FromBody] Cliente novoCliente)
    {
        if (novoCliente == null || string.IsNullOrEmpty(novoCliente.Name))
        {
            return BadRequest("Dados do cliente inválidos.");
        }

        _context.Cliente.Add(novoCliente);
        await _context.SaveChangesAsync();

        return Ok(new { success = true, message = "Cliente cadastrado com sucesso." });
    }

    // ------------------------------------------- LISTA CLIENTES ---------------------------------------//
    [HttpGet("cliente")]
    public async Task<IActionResult> ListarClientes()
    {
        var clientes =  await _context.Cliente.ToListAsync();
        return Ok(clientes);
    }

    // ------------------------------------------- ATUALIZA CLIENTE ---------------------------------------//
    [HttpPut("cliente/{id}")]
    public async Task<IActionResult> AtualizarCliente(int id, [FromBody] Cliente clienteAtualizado)
    {
        var cliente = await _context.Cliente.FirstOrDefaultAsync(client => client.Id == id);
        if (cliente == null)
        {
            return NotFound("Cliente não encontrado.");
        }

        cliente.Name = clienteAtualizado.Name;
        cliente.Email = clienteAtualizado.Email;
        cliente.Telefone = clienteAtualizado.Telefone;

        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Cliente atualizado com sucesso." });
    }

    // ------------------------------------------- DELETA CLIENTE ---------------------------------------//
    [HttpDelete("cliente/{id}")]
    public async Task<IActionResult> DeletarCliente(int id)
    {
        var cliente = await _context.Cliente.FirstOrDefaultAsync(client => client.Id == id);
        if (cliente == null)
        {
            return NotFound("Cliente não encontrado.");
        }

        _context.Cliente.Remove(cliente);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Cliente deletado com sucesso." });
    }

    // === PRODUTOS ===

   // ------------------------------------------- CADASTRA PRODUTO ---------------------------------------//
    [HttpPost("produto")]
    public async Task<IActionResult> CadastrarProduto([FromBody] Produto novoProduto)
    {
        if (novoProduto == null || string.IsNullOrEmpty(novoProduto.Name))
        {
            return BadRequest("Dados do produto inválidos.");
        }

        _context.Produto.Add(novoProduto);
        await _context.SaveChangesAsync();

        return Ok(new { success = true, message = "Produto cadastrado com sucesso." });
    }

   // ------------------------------------------- LISTA PRODUTOS ---------------------------------------//
    [HttpGet("produto")]
    public async Task<IActionResult> ListarProdutos()
    {
        var produtos = await _context.Produto.ToListAsync();
        return Ok(produtos);
    }

    // ------------------------------------------- ATUALIZA PRODUTO ---------------------------------------//
    [HttpPut("produto/{id}")]
    public async Task<IActionResult> AtualizarProduto(int id, [FromBody] Produto produtoAtualizado)
    {
        var produto =  await _context.Produto.FirstOrDefaultAsync(product => product.Id == id);
        if (produto == null)
        {
            return NotFound("Produto não encontrado.");
        }

        produto.Name = produtoAtualizado.Name;
        produto.Price = produtoAtualizado.Price;
        produto.Description = produtoAtualizado.Description;

        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Produto atualizado com sucesso." });
    }

   // ------------------------------------------- DELETA PRODUTO ---------------------------------------//
    [HttpDelete("produto/{id}")]
    public async Task<IActionResult> DeletarProduto(int id)
    {
        var produto = await _context.Produto.FirstOrDefaultAsync(product => product.Id == id);
        if (produto == null)
        {
            return NotFound("Produto não encontrado.");
        }

        _context.Produto.Remove(produto);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Produto deletado com sucesso." });
    }

    // === VENDAS ===

    // ------------------------------------------- CADASTRA VENDA ---------------------------------------//
    [HttpPost("venda")]
    public async Task<IActionResult> CadastrarVenda([FromBody] Vendas novaVenda)
    {
        if (novaVenda == null || novaVenda.ClienteId <= 0 || novaVenda.ProdutoId <= 0)
        {
            return BadRequest("Dados da venda inválidos.");
        }
        var client = await _context.Cliente.FindAsync(novaVenda.ClienteId);
        var produto = await _context.Produto.FindAsync(novaVenda.ProdutoId);
        if(client == null || produto == null)
        {
            return BadRequest("Cliente ou Produto não existe.");
        }

        _context.Vendas.Add(novaVenda);
        await _context.SaveChangesAsync();

        return Ok(new { success = true, message = "Venda cadastrada com sucesso." });
    }
// ------------------------------------------- LISTA VENDAS ---------------------------------------//
    [HttpGet("venda")]
    public async Task<IActionResult> ListarVendas()
    {
        var vendas = await _context.Vendas.ToListAsync();
        return Ok(vendas);
    }

    // ------------------------------------------- CANCELAR VENDA ---------------------------------------//
    [HttpDelete("venda/{id}")]
    public async Task<IActionResult> CancelarVenda(int id)
    {
        var venda = await _context.Vendas.FirstOrDefaultAsync(vendas => vendas.Id == id);
        if (venda == null)
        {
            return NotFound("Venda não encontrada.");
        }

        _context.Vendas.Remove(venda);
       await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Venda cancelada com sucesso." });
    }

    // === FORNECEDORES ===

    // ------------------------------------------- CADASTRA FORNECEDOR ---------------------------------------//
    [HttpPost("fornecedor")]
    public async Task<IActionResult> CadastrarFornecedor([FromBody] Fornecedor novoFornecedor)
    {
        if (novoFornecedor == null || string.IsNullOrEmpty(novoFornecedor.Name))
        {
            return BadRequest("Dados do fornecedor inválidos.");
        }

        _context.Fornecedor.Add(novoFornecedor);
        await _context.SaveChangesAsync();

        return Ok(new { success = true, message = "Fornecedor cadastrado com sucesso." });
    }

   // ------------------------------------------- LISTA FORNECEDORES ---------------------------------------//
    [HttpGet("fornecedor")]
    public async Task<IActionResult> ListarFornecedores()
    {
        var fornecedores =  await _context.Fornecedor.ToListAsync();
        return Ok(fornecedores);
    }

   // ------------------------------------------- DELETA FORNECEDOR ---------------------------------------//
    [HttpDelete("fornecedore/{id}")]
    public async Task<IActionResult> DeletarFornecedor(int id)
    {
        var fornecedor = await _context.Fornecedor.FirstOrDefaultAsync(fornecedor => fornecedor.Id == id);
        if (fornecedor == null)
        {
            return NotFound("Fornecedor não encontrado.");
        }

        _context.Fornecedor.Remove(fornecedor);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Fornecedor deletado com sucesso." });
    }

                                            // === COLABORADORES ===



    [HttpPost("loginColaborador")]
    public async Task<IActionResult> LoginColaborador([FromBody]Colaborador login)
    {
        var userCredentials = await _context.Colaborador.SingleOrDefaultAsync(userLogin => userLogin.Username == login.Username);

        if(userCredentials == null || userCredentials.Password != login.Password)
        {
            return BadRequest(new 
                {
                    succes = false,
                    message = "Usuairo ou senha invalidos, verifique suas credenciais de acesso."
                }
            );
        }
        return Ok(new 
                { 
                    success = true, 
                    message = "Login efetuado com sucesso.", 
                    user = new 
                    {
                        id = userCredentials.Id,
                        username = userCredentials.Username
                    }                                 
                }
            ); 

    }
   // ------------------------------------------- CADASTRA COLABORADOR ---------------------------------------//

    [HttpPost("colaborador")]
    public async Task<IActionResult> CadastrarColaborador([FromBody] Colaborador newColaborador)
    {
        var userExists = await _context.Colaborador.SingleOrDefaultAsync(user => 
                                                        user.Username == newColaborador.Username);

        if(userExists != null)
        {
            return BadRequest(new {message = "Usuario ja existe." });
        }

        string passwordHash = BCrypt.Net.BCrypt.HashPassword(newColaborador.Password);
        var colaborador = new Colaborador
        {
            Username = newColaborador.Username,
            Password = passwordHash,
            Name = newColaborador.Name,
            Email = newColaborador.Email,
            Telefone = newColaborador.Telefone,
        };
        _context.Colaborador.Add(colaborador);
        await _context.SaveChangesAsync();
        return Ok (new { success = true, message = "Colaborador cadastrado com sucesso."});
    }
// ------------------------------------------- GET COLABORADORES ---------------------------------------//
    [HttpGet("colaborador")]
    public async Task<IActionResult> ListarColaboradores(Colaborador colaborador)
    {
        var listColaborador =  await _context.Colaborador.
                                                        Select(colaborador => new
                                                        {
                                                            colaborador.Id,
                                                            colaborador.Name,
                                                            colaborador.Email,
                                                            colaborador.Username,
                                                            colaborador.Telefone
                                                        }).ToListAsync();
        return Ok(listColaborador);
    }
// ------------------------------------------- ATUALIZA COLABORADOR ---------------------------------------//
    [HttpPut("colaborador/{id}")]
    public async Task<IActionResult> AtualizaColaborador(int id, [FromBody] Colaborador colaboradorAtualizado)
    {
        var colaborador =  await _context.Colaborador.FirstOrDefaultAsync(colaborador => colaborador.Id == id);
        if(colaborador == null)
        {
            return NotFound("Colaborador não encontrado.");
        }

        colaborador.Name = colaboradorAtualizado.Name;
        colaborador.Email = colaboradorAtualizado.Email;
        colaborador.Telefone = colaboradorAtualizado.Telefone;
        colaborador.Username = colaboradorAtualizado.Username;
        colaborador.Password = colaboradorAtualizado.Password;

       await  _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Colaborador atualizado com sucesso." });
    }
    // ------------------------------------------- DELETA COLABORADOR ---------------------------------------//
    [HttpDelete("colaborador/{id}")]
    public async Task<IActionResult> DeletarColaborador(int id)
    {
        var colaborador =  await _context.Colaborador.FirstOrDefaultAsync(colaborador => colaborador.Id == id);
        if(colaborador == null)
        {
            return NotFound("Colaborador não encontrado.");
        }

        _context.Colaborador.Remove(colaborador);
        await _context.SaveChangesAsync();
        return Ok(new { success = true, message = "Colaborador deletado com sucesso." });
    }
}
