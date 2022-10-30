# Gaming Library API

- [Gaming Library API](#gaming-library-api)
  - [Create Game](#create-game)
    - [Create Game Request](#create-game-request)
    - [Create Game Response](#create-game-response)
  - [Get Game](#get-game)
    - [Get Game Request](#get-game-request)
    - [Get Game Response](#get-game-response)
  - [Update Game](#update-game)
    - [Update Game Request](#update-game-request)
    - [Update Game Response](#update-game-response)
  - [Delete Game](#delete-game)
    - [Delete Game Request](#delete-game-request)
    - [Delete Game Response](#delete-game-response)

## Create Game

### Create Game Request

```js
POST /games
```

```json
{
	"name": "Final Fantasy IX",
	"description": "A band of thieves are hired to kidnap Princess Garnet of Alexandria. After they succeed, they end up becoming her guardians. And while protecting the fair Princess from a powerful evil...they hold the fate of the world in their hands. Play along on the epic journey filled with danger, mystery, war and love.",
	"releasedYear": "2000",
    "trophies": "52",
    "platinumTrophy": "Yes",
    "multiplayerTrophies": "No",
    "onlineTrophies": "No",
    "genre": ["RPG", "TBS", "Adventure", "Fantasy"],
    "platforms": ["PS1", "PS4", "PS5"]
}
```

### Create Game Response

```js
201 Created
```

```js
Location: {{host}}/Games/{{id}}
```

```json
{
    "id": "0000-0000-0000",
	"name": "Final Fantasy IX",
	"description": "A band of thieves are hired to kidnap Princess Garnet of Alexandria. After they succeed, they end up becoming her guardians. And while protecting the fair Princess from a powerful evil...they hold the fate of the world in their hands. Play along on the epic journey filled with danger, mystery, war and love.",
	"releasedYear": "2000",
    "trophies": "52",
    "platinumTrophy": "Yes",
    "multiplayerTrophies": "No",
    "onlineTrophies": "No",
    "genre": ["RPG", "TBS", "Adventure", "Fantasy"],
    "platforms": ["PS1", "PS4", "PS5"]
}
```

## Get Game

### Get Game Request

```js
GET /games/{{id}}
```

### Get Game Response

```js
200 OK
```

```json
{
    "id": "0000-0000-0000",
	"name": "Final Fantasy IX",
	"description": "A band of thieves are hired to kidnap Princess Garnet of Alexandria. After they succeed, they end up becoming her guardians. And while protecting the fair Princess from a powerful evil...they hold the fate of the world in their hands. Play along on the epic journey filled with danger, mystery, war and love.",
	"releasedYear": "2000",
    "trophies": "52",
    "platinumTrophy": "Yes",
    "multiplayerTrophies": "No",
    "onlineTrophies": "No",
    "genre": ["RPG", "TBS", "Adventure", "Fantasy"],
    "platforms": ["PS1", "PS4", "PS5"]
}
```

## Update Game

### Update Game Request

```js
PUT /games/{{id}}
```

```json
{
	"name": "Final Fantasy IX",
	"description": "A band of thieves are hired to kidnap Princess Garnet of Alexandria. After they succeed, they end up becoming her guardians. And while protecting the fair Princess from a powerful evil...they hold the fate of the world in their hands. Play along on the epic journey filled with danger, mystery, war and love.",
	"releasedYear": "2000",
    "trophies": "52",
    "platinumTrophy": "Yes",
    "multiplayerTrophies": "No",
    "onlineTrophies": "No",
    "genre": ["RPG", "TBS", "Adventure", "Fantasy"],
    "platforms": ["PS1", "PS4", "PS5"]
}
```

### Update Game Response

```js
204 No Content
```
or

```js
201 Created
```

```js
Location: {{host}}/Games/{{id}}
```

## Delete Game

### Delete Game Request

```js
DELETE /games/{{id}}
```

### Delete Game Response

```js
204 No Content
```
