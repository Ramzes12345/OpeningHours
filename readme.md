Hi.
1) Open and run solution
2) Make POST raw call (application/json tyep) to http://localhost:27575/OpeningHours

Part 2: 
This approach for sending data is quite efficient.
But I would perhaps unify sending of the days of the week in a more elegant way.

I assume you mean the N+1 problem? right?
If so, then I will just say that when building queries to the database, we need to rely on logic and simplicity.
I also want to mention that in the communication between the server and the database, this most expensive operation is the establishment of a connection. That is why we need to avoid regular queries to the database and possibly combine several queries into one.
