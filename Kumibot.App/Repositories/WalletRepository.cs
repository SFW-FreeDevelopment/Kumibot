using System.Text.Json;
using Kumibot.App.Models.Betting;

namespace Kumibot.App.Repositories;

public class WalletRepository
{
    private readonly List<Wallet> _wallets;
    private readonly StreamReader _walletStream;
    private readonly string _sFile;
    private const string Noun = "wallets";
    
    public WalletRepository()
    {
        var sCurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;            
        _sFile = Path.Combine(sCurrentDirectory, @$"..\..\..\Data\{Noun}.json");
        _walletStream = new StreamReader(Path.GetFullPath(_sFile));
        _wallets = JsonSerializer.Deserialize<List<Wallet>>(_walletStream.ReadToEnd());
        _walletStream.Close();
    }

    public List<Wallet> GetWallets()
    {
        return _wallets;
    }
    
    public Wallet GetWalletByOwner(ulong id)
    {
        return _wallets.FirstOrDefault(w => w.Owner.Equals(id));
    }
    
    public Wallet AddWallet(Wallet wallet)
    {
        _wallets.Add(wallet);
        File.WriteAllText(_sFile, JsonSerializer.Serialize(_wallets));
        return _wallets.FirstOrDefault(w => w.Owner.Equals(wallet.Owner));
    }
}