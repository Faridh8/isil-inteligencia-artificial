# Steering Behaviours

#### Idea base

Todo se resume a calcular el vector que define el movimiento:

​	**objetivo** => **vector deseado**

Y con eso calcular el vector steer y el resto de vectores de manera mecánica:

```c#
Vector3 velocity; // velocidad del objeto
Vector3 desired; // vector deseado en cada instante
Vector3 steer; // vector de cambio para llegar al vector deseado

float MAX_FORCE = 1.0f; // velocidad del agente
float MAX_STEER = 1.0f; // capacidad de reacción del agente

desired = // cálculo específico para cada movimiento;
steer = Vector3.ClampMagnitude(velocity, MAX_STEER);
velocity += steer;
transform.position += velocity * Time.deltaTime;
```

#### Seek

```c#
// Target: target

desired = (target.tranform.position - transform.position).normalized * MAX_FORCE;
```

#### Seek con rango

```c#
// Vector3 target
// float MAX_RANGE

if (distance < MAX_RANGE)
{
    desired = (target.tranform.position - transform.position).normalized * MAX_FORCE;
}
else
{
    desired = Vector3.zero; // o lo que sea que deba hacer
}
```



#### Arrive

```c#
// Vector3 target
// float MAX_RANGE

if (distance >= MAX_RANGE)
{
    desired = (target.tranform.position - transform.position).normalized * MAX_FORCE;
}
else
{
    desired = (target.tranform.position - transform.position) * MAX_FORCE;
}
```

#### Flee

```c#
desired = -(target.tranform.position - transform.position).normalized * MAX_FORCE
```

#### Flee (con rango)

```c#
// Vector3 target
// float MAX_RANGE

if (distance < MAX_RANGE)
{
    desired = -(target.tranform.position - transform.position).normalized * MAX_FORCE;
}
else
{
    desired = Vector3.zero; // o lo que sea que deba hacer
}
```

#### Random

```c#
// hacer un seek a un target que cambia de posición aleatoriamente cada cierto tiempo
```

