to-text
=======

A little c# extension method helping to print out objects to the console.

###Usage

```c#
var naruto = new Ninja(name:"Naruto Uzumaki", age:12);
```

```c#
naruto.ToText()   
=> Ninja
```

```c#
naruto.ToText(n => n.Name)
=> Ninja: Name = 'Naruto Uzumaki'
```

```c#
naruto.ToText(n => n.Name, n => n.Age)
=> Ninja: Name = 'Naruto Uzumaki'
          Age  = '12'
```
