#include <iostream>
#include <vector>
#include <algorithm>
#include <string>
#include <cmath>
#include <map>
#include <set>
#include <unordered_map>
#include <unordered_set>
#include <stack>
#include <queue>
#include <deque>
#include <list>
#include <bitset>
#include <sstream>
#include <numeric>
#include <limits>
#include <tuple>
#include <functional>
#include <iomanip>
#include <cassert>
using namespace std;

#define mod 1e9 + 7;
#define FOR(a, c) for (int(a) = 0; (a) < (c); (a)++)
#define FORL(a, b, c) for (int(a) = (b); (a) <= (c); (a)++)
#define FORR(a, b, c) for (int(a) = (b); (a) >= (c); (a)--)
#define INF 1000000000000000003
typedef long long int ll;
typedef vector<int> vi;
typedef pair<int, int> pi;
#define F first

void solve()
{
    int n, k;
    cin >> n >> k;

    vector<string> s(k);
    for (int i = 0; i < k; i++)
    {
        cin >> s[i];
    }

    // build bitmask for each position
    vector<int> pos(n);
    for (auto &x : s)
    {
        for (int i = 0; i < n; i++)
        {
            pos[i] |= (1LL << (x[i] - 'a'));
        }
    }

    // find all divisors of n in increasing order
    vector<int> divv;
    for (int i = 1; i <= n; i++)
    {
        if (n % i == 0)
        {
            divv.push_back(i);
        }
    }

    // find minimum valid d
    int ans = 0;
    for (auto &d : divv)
    {
        bool valid = true;
        for (int i = 0; i < d; i++)
        {
            int common = (1LL << 26) - 1;
            for (int j = i; j < n; j += d)
            {
                common &= pos[j];
            }
            if (common == 0)
            {
                valid = false;
                break;
            }
        }
        if (valid)
        {
            ans = d;
            break; // minimum d found
        }
    }

    // build result string of length n
    string result(n, ' ');
    for (int i = 0; i < ans; i++)
    {
        int common = (1LL << 26) - 1;
        for (int j = i; j < n; j += ans)
        {
            common &= pos[j];
        }
        char ch = 'a' + __builtin_ctzll(common);
        for (int j = i; j < n; j += ans)
        {
            result[j] = ch;
        }
    }

    // cout << ans << "\n";
    cout << result << "\n";
}

signed main()
{
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);

    int t;
    cin >> t;
    while (t--)
    {
        solve();
    }

    return 0;
}