# K.Facade
K.Facade busca facilitar a configuração da técnica de estrutura de fachada.

# Começando
## NUGET
```
Install-Package K.Facade -Version 1.1.7
```
## Software dependencies
- **newtonsoft.json** (>= 12.0.1)

## Latest releases
- **Mapeamento**
  - **config.json**: Configuração de rastreio de mapeamento
  - **Contexto de Mapeamento**: Possibilita a criação de um mapeamento fora do contexto global
  - **Alvo**: *Desvio* de mapeamento de implementação
- **Personalização**
  - Herança do Configurador de Registros
  - Herança da *Factory* de Mapeamento
  - Facade com construtor

# Como Utilizar
## Interfaces
- Escreva suas interfaces sem necessidade de dependencia com o K.Facade


**Exemplo**
```csharp
public interface IUserSign 
{
	bool SignIn(string userName, string password);
	bool SignOut(string token);
}
```
## Implementação
- Implemente a interface


**Exemplo**
```csharp
public class UserSign: IUserSign
{
	public bool SignIn(string userName, string password) 
	{
		//...
		return true;
	}
	public bool SignOut(string token) 
	{
		//...
		return true;
	}
}
```
## Mapeamento
Aqui existem duas maneiras de fazer o mapeamento das implementações.
### Mapeamento por Atributo
- Utilize o atributo `[SetFacade]` para definir o mapeamento
  - O atributo exige um parametro do tipo `Type`
- É necessário uma configuração na aplicação


**Exemplo**
```csharp
[SetFacade(typeof(IUserSign))]
class UserSign: IUserSign
{
	public bool SignIn(string userName, string password) 
	{
		//...
		return true;
	}
	public bool SignOut(string token) 
	{
		//...
		return true;
	}
}
```
### Mapeamento por Código
- Define um mapeamento através da codificação
- Pode ser definido na aplicação

**Exemplo**
```csharp
public class Startup
{
	public Startup()
	{
		DomainFactory.Mapper.Map(a => a.Add<IUserSign, UserSign>());
	}
}
```

### Mapeamento com Alvos
- Utilizado para definir mais de uma implementação para a mesma interface
**Exemplo Atributo**
```csharp
//Mapeamento por atributo
[SetFacade(typeof(IUserSign), "TARGET_NAME")]

//Mapeamento por código
DomainFactory.Mapper.Map(a => a.Add<IUserSign, UserSign>("TARGET_NAME"));
```

### Mapeamento Instanciado
Cada vez que uma facade é chamada a Factory cria uma instancia com base no mapeamento, 
mas você pode fazer um mapeamento instanciado.
- Trata-se de passar uma instancia da implementação para o mapeamento
- Somente aplicável no modelo **Mapeamento por código**
- Ideal para projeto de Teste Utilizando *mock*


**Exemplo Código**
```csharp
//Mapeamento Comum
DomainFactory.Mapper.Map(a => a.Add<IUserSign>(new UserSign()));

//Mapeamento com Target
DomainFactory.Mapper.Map(a => a.Add<IUserSign>(new UserSign(), "TARGET_NAME"));
```

### Configurando Carregamento de Mapeamento por atributo
Para que o mapeamento por atributo funcione, é necessário que seja carregado junto a aplicação.
1. Crie um projeto de aplicação (Console, Windows, Web...)
2. Crie um arquivo "config.json" (por padrão)
	
	2.1. No arquivo config.json modifique a propriedade '*Copiar para diretório de saída*' para ***Copiar***
3. Conteúdo do config.json
```json
{
  "facade": {
    "map": {
      "domain": [ /*Array de Assemblies com código Implementado*/ ]
    }
  }
}
```

4. Na aplicação execute o código
```csharp
public class Startup
{
	public Startup()
	{
		DomainFactory.Mapper.LoadMapping();
	}
}
```
## Obtendo Instância Mapeada
- Utilize o método `DomainFactory.GetInstance`para obter uma instancia do mapeamento
```csharp
//Obter Intancia padrão
IUserSign userSign = DomainFactory.GetInstance<IUserSign>();
//Obter instancia com alvo
IUserSign userSignTarg = DomainFactory.GetInstance<IUserSign>("TARGET_NAME");
```

# Úteis
[Projeto de teste](../tests/k.facade.tests/)