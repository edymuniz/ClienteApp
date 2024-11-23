# ClienteApp
Subir 
docker-compose down
docker-compose up -d

Iniciar o Replica Set:
Agora, você pode conectar-se ao contêiner do MongoDB e inicializar o replica set usando o mongosh.

docker exec -it <container_id> mongosh
Dentro do shell do mongosh, execute o comando para iniciar o replica set:

js
Copiar código
rs.initiate({
    _id: "rs0",
    members: [
        { _id: 0, host: "localhost:27017" }
    ]
})