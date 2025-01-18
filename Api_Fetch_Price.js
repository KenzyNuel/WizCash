// scripts.js
document.addEventListener("DOMContentLoaded", () => {
    const btcPrice = document.getElementById("btc-price");
    const ethPrice = document.getElementById("eth-price");
    const zecPrice = document.getElementById("zec-price");

    async function fetchPrices() {
        try {
            const response = await fetch("https://api.coingecko.com/api/v3/simple/price?ids=bitcoin,ethereum,zcash&vs_currencies=usd");
            const data = await response.json();

            btcPrice.textContent = `$${data.bitcoin.usd.toFixed(2)}`;
            ethPrice.textContent = `$${data.ethereum.usd.toFixed(2)}`;
            zecPrice.textContent = `$${data.zcash.usd.toFixed(2)}`;
        } catch (error) {
            console.error("Error fetching prices:", error);
        }
    }

    // Fetch prices every 60 seconds
    fetchPrices();
    setInterval(fetchPrices, 60000);
});
