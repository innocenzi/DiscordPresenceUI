# LEA-4

LEA stands for **L**eijnen **E**ncryption **A**lgorithm, 4 being the size of the key.

# Using the library

## LEA class

The LEA class contains the Key object and the methods used to generate a public and a private key.

```csharp
class LEA
{
  class Key { }
  Key GeneratePublicKey();
  Key GetPrivateKey(publicKey);
}
```

## LEA4 class

You will usually use the `LEA4` class, which contains an override of the key generation methods.

```csharp
// generates a public key
Key key = LEA4.GeneratePublicKey();

// generates a private key
Key secret = LEA4.GetPrivateKey(key);
```
### Obfuscate

You can obfuscate an array of bytes using the `Obfuscate` method.
```csharp
byte[] bytes = File.ReadAllBytes(file);
Key key = LEA4.GeneratePublicKey();
LEA4.Obfuscate(bytes, key);
```

You can deobfuscate that array using the `Obfuscate` method, but with the private key.
```csharp
byte[] bytes = File.ReadAllBytes(file);
LEA4.Obfuscate(bytes, privateKey);
```

### Encrypt and decrypt files

A helper class inside `LEA4`, the `FileCryptography` class, will help in the process of encrypting and decrypting files. It handles key errors.

```csharp
// encryption
FileInfo input = new FileInfo(...);
FileInfo output = new FileInfo(...);
Key key = LEA4.GeneratePublicKey();
LEA4.FileCryptography.Encrypt(input, output, key);

// decryption
input = new FileInfo(...);
output = new FileInfo(...);
Key secret = LEA4.GetPrivateKey(key);
LEA4.FileCryptography.Decrypt(input, output, secret);
```
