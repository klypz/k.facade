# K.Facade
K.Facade busca facilitar a configura��o da t�cnica de estrutura de fachada.

# Come�ando
## NUGET
```
Install-Package K.Facade -Version 1.1.7
```
## Software dependencies
- **newtonsoft.json** (>= 12.0.1)

## Latest releases
- **Mapeamento**
  - **config.json**: Configura��o de rastreio de mapeamento
  - **Contexto de Mapeamento**: Possibilita a cria��o de um mapeamento fora do contexto global
  - **Alvo**: *Desvio* de mapeamento de implementa��o
- **Personaliza��o**
  - Heran�a do Configurador de Registros
  - Heran�a da *Factory* de Mapeamento
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
## Implementa��o
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
Aqui existem duas maneiras de fazer o mapeamento das implementa��es.
### Mapeamento por Atributo
- Utilize o atributo `[SetFacade]` para definir o mapeamento
  - O atributo exige um parametro do tipo `Type`
- � necess�rio uma configura��o na aplica��o


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
### Mapeamento por C�digo
- Define um mapeamento atrav�s da codifica��o
- Pode ser definido na aplica��o

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
- Utilizado para definir mais de uma implementa��o para a mesma interface
**Exemplo Atributo**
```csharp
//Mapeamento por atributo
[SetFacade(typeof(IUserSign), "TARGET_NAME")]

//Mapeamento por c�digo
DomainFactory.Mapper.Map(a => a.Add<IUserSign, UserSign>("TARGET_NAME"));
```

### Mapeamento Instanciado
Cada vez que uma facade � chamada a Factory cria uma instancia com base no mapeamento, 
mas voc� pode fazer um mapeamento instanciado.
- Trata-se de passar uma instancia da implementa��o para o mapeamento
- Somente aplic�vel no modelo **Mapeamento por c�digo**
- Ideal para projeto de Teste Utilizando *mock*


**Exemplo C�digo**
```csharp
//Mapeamento Comum
DomainFactory.Mapper.Map(a => a.Add<IUserSign>(new UserSign()));

//Mapeamento com Target
DomainFactory.Mapper.Map(a => a.Add<IUserSign>(new UserSign(), "TARGET_NAME"));
```

### Configurando Carregamento de Mapeamento por atributo
Para que o mapeamento por atributo funcione, � necess�rio que seja carregado junto a aplica��o.
1. Crie um projeto de aplica��o (Console, Windows, Web...)
2. Crie um arquivo "config.json" (por padr�o)
	
	2.1. No arquivo config.json modifique a propriedade '*Copiar para diret�rio de sa�da*' para ***Copiar***
3. Conte�do do config.json
```json
{
  "facade": {
    "map": {
      "domain": [ /*Array de Assemblies com c�digo Implementado*/ ]
    }
  }
}
```

4. Na aplica��o execute o c�digo
```csharp
public class Startup
{
	public Startup()
	{
		DomainFactory.Mapper.LoadMapping();
	}
}
```
## Obtendo Inst�ncia Mapeada
- Utilize o m�todo `DomainFactory.GetInstance`para obter uma instancia do mapeamento
```csharp
//Obter Intancia padr�o
IUserSign userSign = DomainFactory.GetInstance<IUserSign>();
//Obter instancia com alvo
IUserSign userSignTarg = DomainFactory.GetInstance<IUserSign>("TARGET_NAME");
```

# �teis
[Projeto de teste](../tests/k.facade.tests/)