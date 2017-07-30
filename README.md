# AriaNet

Yet another Aria2 JSON-RPC library for .NET platforms

# Documents

Please refer to Aria2 official [JSON-RPC interface document](https://aria2.github.io/manual/en/html/aria2c.html#rpc-interface).

Most of the APIs are implemented except:
	
- `aria2.tellWaiting([secret, ]offset, num[, keys])`
- `aria2.tellStopped([secret, ]offset, num[, keys])`
- `aria2.changePosition([secret, ]gid, pos, how)`
- `aria2.changeUri([secret, ]gid, fileIndex, delUris, addUris[, position])`

These APIs above are not quite useful in my apps currently. But I will consdider implementing them later when I'm free.

# Credit

- Aria2 project
- Yortw's [Spooky library](https://github.com/Yortw/Spooky)

# Licence

CC-BY-NC-SA 3.0 Australian Licence, NOT FOR COMMERCIAL PURPOSES.