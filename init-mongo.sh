#!/bin/bash

# Esperar MongoDB inicializar completamente
until mongo --eval "print(\"Esperando inicialização do MongoDB...\")"; do
    sleep 2
done

# Iniciar o Replica Set
mongo --eval '
    rs.initiate({
        _id: "rs0",
        members: [
            { _id: 0, host: "mongodb:27017" }  # Usar o nome do serviço MongoDB definido no docker-compose.yml
        ]
    })
'

echo "Replica set iniciado com sucesso."
